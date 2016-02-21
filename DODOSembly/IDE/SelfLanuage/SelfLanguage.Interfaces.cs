namespace SelfLanguage.Interfaces {
    /// <summary>
    /// Interface used to define a type convertible from and to string using 
    /// The FromString method(has to be static and public)
    /// The ToMemoryString method(has to be public)
    /// </summary>
    /// <typeparam name="T">Type of the class</typeparam>
    interface IStringable {
        object FromString(string s);
        string ToMemoryString();
    }
}
