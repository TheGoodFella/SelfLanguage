using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using SelfLanguage.Interfaces;
using SelfLanguage.Utility;
using SelfLanguage.Exceptions;
using SelfLanguage.SLRegex;
using SelfLanguage.TypeAlias;

namespace SelfLanguage {
    /// <summary>
    /// Main Language class
    /// </summary>
    public class Language {
        private List<Action> RegisterInterrupt { get; set; }
        private int _pointer { get; set; }
        private char[] Temp_mem { get; set; }
        private RegexContainer DestinationSelecter { get; set; }
        private SelfTypes TypeAliasContainer { get; set; }
        private ConversionSelector Conversion { get; set; }
        /// <summary>
        /// The Ram, contains all the variables
        /// </summary>
        public List<Variable> Ram { get; private set; }
        /// <summary>
        /// The stack, values can be pushed here
        /// </summary>
        public Stack<int> CommandStackCarry { get; private set; }
        /// <summary>
        /// All the SelfLanguage Commands are contained here
        /// </summary>
        public Dictionary<string, Action> CommandList { get; private set; } //int is where the pointer is when calling the command
        /// <summary>
        /// This is the memory where the program is loaded
        /// </summary>
        public char[] Memory { get; private set; }
        /// <summary>
        /// This is where the loaded program starts
        /// </summary>
        public char ProgramEntryPoint { get; set; }
        /// <summary>
        /// This is the event rised every time a command is called
        /// </summary>
        public Action<Logging> Debug { get; set; }
        /// <summary>
        /// This a logger, here you can write with the n command
        /// </summary>
        public Action<Logging> GenericLog { get; set; }
        /// <summary>
        /// This is the event rised on Exception
        /// </summary>
        public event Action<Logging> ExceptionRised; 
        /// <summary>
        /// This is the pre-command char, a command to be executed, have to have this in front of him
        /// </summary>
        public readonly char PreCommand = '\0';
        /// <summary>
        /// This is the pre-pointer indicator, delimits pointer start and end
        /// </summary>
        public readonly char PointerIndicator = '&';
        /// <summary>
        /// Creates a Language instance with the given memory
        /// </summary>
        /// <param name="_memorySize">How much memory is needed</param>
        public Language(int _memorySize) {
            DestinationSelecter = new RegexContainer();
            CommandStackCarry = new Stack<int>();
            TypeAliasContainer = new SelfTypes();
            Memory = new char[_memorySize];
            Memory = Memory.Select((s) => '\\').ToArray();
            RegisterInterrupt = new List<Action>();
            Ram = new List<Variable>();
            CommandList = new Dictionary<string, Action>();
            CommandList.Add("j" , () => JumpCommand(_pointer));          //Jump
            CommandList.Add("p" , () => PopOrPush(_pointer));            //pop is 0 or push that is 1
            CommandList.Add("i" , () => Interrupt(_pointer));            //Interrupt n
            CommandList.Add("s" , () => SetCarry(_pointer));             //Set value carry
            CommandList.Add("n" , () => WriteValueCarry());              //Write value carry in logger
            CommandList.Add("m" , () => Move(_pointer+2));               //Move&Here;what
            CommandList.Add("a" , ()=> Add(_pointer));                   //Add here;so_much
            CommandList.Add("\\", () => _pointer = int.MaxValue - 1);    //End of program
        }
        #region Commands
        #region <Misc>
        /// <summary>
        /// Runs the program
        /// </summary>
        /// <param name="ProgramEntryPoint">Where the program is going to start</param>
        /// <param name="debug">Executes the program in debug mode (default false)</param>
        public void Run(int ProgramEntryPoint,bool debug=false) {
            var end_o_P = false;
            _pointer = ProgramEntryPoint;
            try {
                if (Memory[ProgramEntryPoint] != PreCommand) { throw new InvalidProgramEntryPointException(); }
                while (!end_o_P) {
                    if (Memory[_pointer] == PreCommand) {
                        if (debug) { Debug(new Logging(Convert.ToString(Memory[_pointer + 1]), _pointer)); }
                        CommandList[Convert.ToString(Memory[_pointer + 1])]();
                    }
                    _pointer++;
                    if (_pointer < 0 || _pointer > Memory.Length) {
                        return;
                    }
                }
            } catch (Exception e) {
                ExceptionRised(new Logging(e.Message,_pointer,e));
            }
        }
        /// <summary>
        /// Load in the memory the string s overwriting from the EntryPoint to s.Length
        /// </summary>
        /// <param name="s">String to be loaded</param>
        /// <param name="EntryPoint">Where to load the string</param>
        public void LoadInMemory(string s, int EntryPoint) {
            if (EntryPoint + s.Length > Memory.Length) {
                throw new OutOfMemoryException(string.Format("The memory from {0} to {1} do not fit the string that is {2} char long", EntryPoint, Memory.Length, s.Length));
            } else {
                for (int i = 0; i < s.Length; i++) {
                    Memory[EntryPoint + i] = s[i];
                }
            }
        }
        /// <summary>
        /// Moves pointer to a new point, like the assembly jmp
        /// </summary>
        private void JumpCommand(int pointer) {
            var v = GetLitteral(pointer +2);
            if (v.Contains(';')) {
                var where = Convert.ToInt32(v.Split(';').ElementAt(0));
                var condition = v.Split(';').ElementAt(1);
                if (!DestinationSelecter.IsConditionalJump(condition)) {
                    throw new InvalidJumpException(string.Format("The condition > {0} < is not well formed",condition));
                }
                var expect = condition.First();
                var compare = condition.Skip(1).Select(s=>Convert.ToString(s)).Aggregate((a,b) => a+b);
                var returned = Getter(compare);
                if (DestinationSelecter.JumpIntToBool(Convert.ToInt32(returned), Convert.ToString(expect))) {
                    _pointer = where-1;
                }
            } else {
                _pointer = Convert.ToInt32(v) -1 ;
            }
        }
        private void Add(int pointer) {
            var command = GetLitteral(pointer + 2).Split(';');
            if (command.Length != 2) {
                throw new InvalidOperationException("The add got called with a not valid litteral statement");
            }
            var ptr = Convert.ToInt32(command.ElementAt(0));
            var how_m = Convert.ToInt32(command.ElementAt(1));
            Memory[ptr] = Convert.ToChar(Convert.ToInt32(Memory[ptr]) + how_m);
        }
        #endregion
        #region <Move>
        private void Move(int pointer) {  //God is here bby   for ram is R:name:[value]:[type=string] || For memory is a N(0, Memory.Lenght) || compare is (type:toC1:toC2)
            var v = GetLitteral(pointer);
            var targets = v.Split(';');
            if (targets.Length != 2) { throw new InvalidMoveException(string.Format("The move is not well formed, {0} is not a valid move argument",targets)); }
            var destination = targets[0];
            var source = targets[1];
            var to_move = Getter(source);
            Setter(destination, to_move);
        }
        private void Setter(string destination, string to_move) {
            var dest = DestinationSelecter.IsCommand(destination);
            if (dest == SelfLanguageDestination.Ram) {
                var dst = destination.Split(':');
                var name = dst.ElementAtOrDefault(1);
                var value = dst.ElementAtOrDefault(2);
                var type = dst.ElementAtOrDefault(3);
                HandleToRam(string.Concat(name, ":", to_move, ":", type));
            }else if(dest == SelfLanguageDestination.Stack){
                CommandStackCarry.Push(Convert.ToInt32(to_move));
            }else if(dest == SelfLanguageDestination.StackMultiChar){
                to_move.ToList().ForEach((s) => CommandStackCarry.Push(Convert.ToInt32(s)));
            }else if(dest == SelfLanguageDestination.Number) {
                LoadInMemory(to_move, Convert.ToInt32(destination));
            } else if(dest == SelfLanguageDestination.None){
                throw new InvalidMoveException(string.Format("The destination {0} is not well formed",destination));
            } else {
                throw new NotImplementedException(); //HTF
            }
        }
        
        private string Getter(string source) {
            var dest = DestinationSelecter.IsCommand(source);
            if (dest == SelfLanguageDestination.Ram) { //is a Ram source
                return HandleFromRam(source);
            } else if (dest == SelfLanguageDestination.Here) { //TODO
                return source.Replace("^", "");
            } else if (dest == SelfLanguageDestination.Stack) { //Could be buggy cause of a R containing a -? keep the order this way 
                return Convert.ToString(CommandStackCarry.Pop());
            } else if(dest == SelfLanguageDestination.Number){
                return HandleFromMemory(Convert.ToInt32(source));
            }else if(dest == SelfLanguageDestination.Compare){
                return Convert.ToString(Compare(source));
            } else if(dest == SelfLanguageDestination.None){
                throw new InvalidGetterException(string.Format("The get operation with the > {0} < source is not valid", source));
            }else{
                throw new NotImplementedException(); //HTF
            }
        }

        /// <summary>
        /// Compares 2 therms in assuming they are in the given type
        /// </summary>
        /// <param name="therms">(type:th1:th2)</param>
        /// <returns>Equals, 1 is false and 0 is true; Compare \< is 1, \> is 2, 0 is = </returns>
        private int Compare(string therms){
            var elemtents = therms.Replace("(", "").Replace(")", "").Split('|');
            var cmp_type = elemtents.ElementAtOrDefault(0); //Type
            var first = elemtents.ElementAtOrDefault(1);    //First
            var second = elemtents.ElementAtOrDefault(2);   //Second
            first = Getter(first);
            second = Getter(second);
            var type = Type.GetType(cmp_type) ?? TypeAliasContainer.GetFromAlias(cmp_type);
            var variable = GetVariableOfType(type);
            if ((variable is IComparable)&& (variable is IConvertible)) {
                var new_f = Convert.ChangeType(first, type);
                var new_s = Convert.ChangeType(second, type);
                var compared = ((dynamic)new_f).CompareTo(new_s);
                return compared ==0 ? 0 : compared == -1?1:compared == 1?2:-1;
            } else if(variable is IConvertible) {
                var new_f = Convert.ChangeType(first, type);
                var new_s = Convert.ChangeType(second, type);
                return new_f.Equals(new_s) ? 0 : 1;
            } else {
                return ((object)first).Equals((object)second) ? 0 : 1;
            }
        }
        
        private void HandleToRam(string generator) {
            var dst1 = generator.Split(':');
            var name = dst1.ElementAtOrDefault(0); //Name
            var value = dst1.ElementAtOrDefault(1);//Value
            var type = dst1.ElementAtOrDefault(2); //Type
            //Remove if exsists the variable from ram
            if(Ram.Any((s) => s.Name == name)){ Ram.Remove(Ram.First((s) => s.Name == name));}
            //The variable is not in ram and has to be created
            var actual_type = Type.GetType(type) ?? TypeAliasContainer.GetFromAlias(type);
            if (actual_type == null) { throw new InvalidVariableTypeException(string.Format("The type {0} is not a valid .Net or SelfLanguage type",type)); }
            var convert = Conversion.GetConversion(actual_type);
            var obj = GetVariableOfType(actual_type);
            if (convert.Any(s => s== PossibleConversion.IStringable)) {
                dynamic o = obj;
                Ram.Add(new Variable(o.FromString(value), name));
            } else if (convert.Any(s=>s== PossibleConversion.IConvertible)) {
                var o = Convert.ChangeType(value, obj.GetType());
                Ram.Add(new Variable(o, name));
            } else if (convert.Any(s=>s== PossibleConversion.Constructor)) {
                var o = obj.GetType().GetConstructors().First((s) => s.GetParameters().Length == 1 && s.GetParameters().First().GetType() == typeof(string));
                Ram.Add(new Variable(o, name));
            } else if (convert.Any(s=>s == PossibleConversion.FromStringImplicit)) {//is the type implicitally convertible from string
                obj = value;
                Ram.Add(new Variable(obj, name));
            }else if(convert.Any(s=> s== PossibleConversion.FromStringExplicit)){
                obj = value; //TODO
            }else if(obj.GetType() is object){
                obj = value;
                Ram.Add(new Variable(obj, name));
            }else {
                throw new InvalidVariableTypeException("The type {0} is not castable or convertible from string, and it does not have a constructor using one string argument");
            }
            
        }
        private string HandleFromRam(string variableName) {
            var new_source = variableName.Split(':');
            var name = new_source.ElementAtOrDefault(1); //Name
            var value = new_source.ElementAtOrDefault(2);//Value
            var type = new_source.ElementAtOrDefault(3); //Type
            var to_put = Ram.FirstOrDefault(s => s.Name == name);
            var convert = Conversion.GetConversion(Type.GetType(type));
            if (to_put == null) { throw new NotDefinedVariableException(string.Format("The varible {0} is not defined", name)); } else {
                if (convert.Any(s=>s== PossibleConversion.IStringable)) {
                    dynamic c = to_put;
                    return c.ToMemoryString();
                } else if (convert.Any(s=> s== PossibleConversion.IConvertible)) {
                    return Convert.ToString(to_put.IncapsulatedValue);
                } else {
                    return to_put.IncapsulatedValue.ToString();
                }
            }
        }
        private string HandleFromMemory(int pointer) {
            return GetLitteral(pointer);
        }
        private object GetVariableOfType(Type t) {
            if (t.IsValueType || t.GetType().GetConstructors().Any((s)=>s.GetParameters().Length ==0)) {
                return Activator.CreateInstance(t);
            }else if(t == typeof(string)){
                return "";
            } else { 
                return null; 
            }
        }
        #endregion
        #region <Interrupt>
        /// <summary>
        /// Use this function to define an interrupt you can call using the i command
        /// </summary>
        /// <param name="f">The Interrupt to be executed</param>
        /// <param name="where">Number to be given</param>
        public void DefineInterrupt(Action f, int where) {
            for (var i = 0; RegisterInterrupt.Count <= where; i++) {
                if (RegisterInterrupt.Count < i) { RegisterInterrupt.Add(EmptyInterrupt); }
            }
            RegisterInterrupt[where] = f;
        }
        /// <summary>
        /// Not defined interrupt
        /// </summary>
        private void EmptyInterrupt() {
            throw new EmptyInterruptException();
        }
        private void Interrupt(int i) {
            RegisterInterrupt[GetNFrom(i + 2)]();
        }

        #endregion
        #region <Working_with_command_carry>
        /// <summary>
        /// Write using the GenericLog a Log Object
        /// </summary>
        private void WriteValueCarry() {
            GenericLog(new Logging(Convert.ToString((char)CommandStackCarry.Pop()), _pointer));
        }
        /// <summary>
        /// Set the CommandValueCarry
        /// </summary>
        /// <param name="i">Pointer</param>
        private void SetCarry(int i) {
            CommandStackCarry.Push(GetNFrom(i + 2));
        }
        #endregion
        #region <Pop_and_push>
        /// <summary>
        /// Popa is 0, pusha is 1
        /// </summary>
        /// <param name="i"></param>
        private void PopOrPush(int i) {
            if (GetNFrom(i + 2) == 0) { Popa(); } else { Pusha(); }
        }
        /// <summary>
        /// Assembly pop all memory
        /// </summary>
        private void Popa() {
            Memory = Temp_mem;
        }
        /// <summary>
        /// Assembly push all memory
        /// </summary>
        private void Pusha() {
            Temp_mem = Memory;
        }
        #endregion
        #region <Get_values_from_pointer>
        /// <summary>
        /// Parse the pointer from
        /// </summary>
        private int GetNFrom(int pointer) {
            var cumulate = "";
            var v = 1;
            if (Memory[pointer] != PointerIndicator) { throw new InvalidPointerException(); }
            pointer++;
            for (int i = pointer; i < Memory.Length; i++) {
                if (Memory[i] != PointerIndicator && Memory[i] != PreCommand) {
                    cumulate += Memory[i];
                } else {
                    if (cumulate.Contains("^")) { return _pointer; }
                    return Convert.ToInt32(cumulate);
                }
                if (cumulate.Contains("^")) { return _pointer; }
                if (!int.TryParse(cumulate, out v)) { throw new InvalidPointerException(); }
            }
            return Convert.ToInt32(cumulate);

        }
        /// <summary>
        /// Get the litteral from the pointer char on to another
        /// </summary>
        private string GetLitteral(int pointer) {
            var to_r = "";
            if (Memory[pointer] != PointerIndicator) { throw new InvalidPointerException(); }
            pointer++;
            for (int i = pointer; i < Memory.Length; i++) {
                if (Memory[i] != PointerIndicator && Memory[i] != PreCommand) {
                    to_r += Memory[i];
                } else {
                    return to_r;
                }
            }
            return to_r;
        }
        #endregion
        #endregion
    }
}