using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using SelfLanguage.Interfaces;
using SelfLanguage.Utility;
using SelfLanguage.Exceptions;

namespace SelfLanguage {
    public class Language {
        private List<Action> RegisterInterrupt { get; set; }
        private int _pointer { get; set; }
        private char[] Temp_mem { get; set; }

        public List<Variable> Ram { get; private set; }
        public Stack<int> CommandStackCarry { get; private set; }

        public Dictionary<string, Action> CommandList { get; private set; } //int is where the pointer is when calling the command
        public char[] Memory { get; private set; }
        public char ProgramEntryPoint { get; set; }

        public Action<Logging> Debug { get; set; }
        public Action<Logging> GenericLog { get; set; }
        public event Action<Logging> ExceptionRised;

        public readonly char PreCommand = '\0';
        public readonly char PointerIndicator = '&';

        public Language(int _memorySize) {
            CommandStackCarry = new Stack<int>();
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
        /// Start the program
        /// </summary>
        /// <param name="ProgramEntryPoint">Where to start</param>
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
        /// <param name="pointer"></param>
        private void JumpCommand(int pointer) {
            _pointer = GetNFrom(pointer += 2) - 1;
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
        public void Move(int pointer) {  //God is here bby   for ram is R:name:[value]:[type=string] || For memory is a N(0, Memory.Lenght) || compare is (type:toC1:toC2)
            var v = GetLitteral(pointer);
            var targets = v.Split(';');
            if (targets.Length != 2) { throw new InvalidMoveException(); }
            var destination = targets[0];
            var source = targets[1];
            var to_move = "";
            to_move = variableGetter(source);
            if (destination.Contains("R")) {
                var dst = destination.Split(':');
                var name = dst.ElementAtOrDefault(1);
                var value = dst.ElementAtOrDefault(2);
                var type = dst.ElementAtOrDefault(3);
                HandleToRam(string.Concat(name,":",to_move,":",type));
            } else {
                LoadInMemory(to_move, Convert.ToInt32(destination));
            }
        }
        private string variableGetter(string source) {
            if (source.Contains("R")) { //is a Ram source
                return HandleFromRam(source);
            } else if (source.Contains("^")) {
                return source.Replace("^", "");
            } else if (source.Contains("-")) { //Could be buggy cause of a R containing a -? keep the order this way 
                return Convert.ToString(CommandStackCarry.Pop());
            } else {
                return HandleFromMemory(Convert.ToInt32(source));
            }
        }
        private int Compare(string therms){
            var elemtents = therms.Replace("(", "").Replace(")", "").Split(':');
            var cmp_type = elemtents.ElementAtOrDefault(0);
            var first = elemtents.ElementAtOrDefault(1);
            var second = elemtents.ElementAtOrDefault(2);
            first = variableGetter(first);
            second = variableGetter(second);
            var type = Type.GetType(cmp_type);
            if ((GetVariableOfType(type) is IComparable)&&(GetVariableOfType(type) is IConvertible)) {
                var new_f = Convert.ChangeType(first, type);
                var new_s = Convert.ChangeType(second, type);
                return ((dynamic)new_f).CompareTo(new_s);
            }
            return 0;
        }
        
        private void HandleToRam(string generator) {
            var dst1 = generator.Split(':');
            var name = dst1.ElementAtOrDefault(0); //Name
            var value = dst1.ElementAtOrDefault(1);//Value
            var type = dst1.ElementAtOrDefault(2); //Type
            //Remove if exsists the variable from ram
            if(Ram.Any((s) => s.Name == name)){ Ram.Remove(Ram.First((s) => s.Name == name));}
            //The variable is not in ram and has to be created
            var actual_type = Type.GetType(type);
            //var obj = actual_type.GetConstructors().First((s) => s.GetParameters().Length == 0 ).Invoke(new object[] { });
            var obj = GetVariableOfType(actual_type);
            if (obj!=null && actual_type.GetInterfaces().Any((s) => s == typeof(IStringable<>).MakeGenericType(obj.GetType()))) {
                dynamic o = obj;
                Ram.Add(new Variable(o.FromString(value), name));
                return;
            } else if (actual_type.GetInterfaces().Any((e) => e == typeof(IConvertible))) {
                var o = Convert.ChangeType(value, obj.GetType());
                Ram.Add(new Variable(o, name));
                return;
            } else if (actual_type.GetConstructors().Any((e) => e.GetParameters().Length == 1 && e.GetParameters().First().GetType() == typeof(string))) {
                var o = obj.GetType().GetConstructors().First((s) => s.GetParameters().Length == 1 && s.GetParameters().First().GetType() == typeof(string));
                Ram.Add(new Variable(o, name));
                return;
            }
            
        }
        private string HandleFromRam(string variableName) {
            var new_source = variableName.Split(':');
            var name = new_source.ElementAtOrDefault(1); //Name
            var value = new_source.ElementAtOrDefault(2);//Value
            var type = new_source.ElementAtOrDefault(3); //Type
            var to_put = Ram.FirstOrDefault((s) => s.Name == name);
            if (to_put == null) { throw new NotDefinedVariableException(string.Format("The varible {0} is not defined", name)); } else {
                if (to_put.GetType().GetInterfaces().Any((s) => s == typeof(IStringable<>).MakeGenericType(to_put.GetType()))) {
                    dynamic c = to_put;
                    return c.ToMemoryString();
                } else if (to_put.GetType().GetInterfaces().Any((s) => s == typeof(IConvertible))) {
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
        #region <Generation>
        private object GenerateFromString(Type type, string generator) {
            object o = new object();
            if (TryCreateFromStringConstructor(type, generator, out o)) { return o; } else if (TryCreateFromStringConvert(type, generator, out o)) { return o; } else {
                throw new InvalidTypeGeneratorException();
            }
        }
        private bool TryCreateFromStringConvert(Type t, string generator, out object o) {
            if (t.GetInterfaces().Any((s) => s == typeof(IStringable<>).MakeGenericType(new Type[] { t }))) { //Fanculo al runtime

                o = t.GetMethod("FromString", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[] { generator });
                return true;
            }
            o = null;
            return false;
        }
        private bool TryCreateFromStringConstructor(Type type, string generator, out object o) {
            var v = type.GetConstructors();
            var string_constructor = v.Where((s) => s.GetParameters().Length == 1 && s.GetParameters().FirstOrDefault().GetType() == typeof(string));
            if (string_constructor.Count() == 0) {
                o = null;
                return false;
            } else {
                object to_r = string_constructor.First().Invoke(new object[] { generator });
                o = to_r;
                return true;
            }
        }
        #endregion
        #region <Interrupt>
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
        /// <summary>
        /// Popa is 0, pusha is 1
        /// </summary>
        /// <param name="i"></param>
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
        /// Calls the interrupt defined after the i command
        /// </summary>
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