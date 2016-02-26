using System;
using IDE;
using SelfLanguage;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void LanguageCreation() {
            var v = new Language(100);
            Assert.IsNotNull(v);
        }
        [TestMethod]
        public void MoveTest() {
            var v = new Language(100);
            v.ExceptionRised += s => { };
            v.Debug = s => {};
            v.LoadInMemory("\0m&R:adsf::obj&^123", 0);
            v.LoadInMemory("\0m&R:adsf::str&^123", 0);
            v.LoadInMemory("\0m&R:adsf::int&^123", 0);
            Assert.IsFalse(v.Ram.Count == 3);
        }
    }
}
