﻿using Frontend.Core.Converting.Operations.CopyMod;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frontend.Core.Tests.Converting
{
    [TestClass]
    public class SaveGameNameTranslatorTest : UnitTestBase
    {
        private SaveGameNameTranslator translator;

        protected override void OnCleanup()
        {
            base.OnCleanup();
            translator = null;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            translator = new SaveGameNameTranslator();
        }

        [TestMethod]
        public void Test_Normal_Name()
        {
            // Arrange
            var saveName = "testname";
            var expectedResult = "testname";

            // Act
            var result = translator.TranslateName(saveName);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestName_With_Whitespaces()
        {
            // Arrange
            var saveName = "test name";
            var expectedResult = "test_name";

            // Act
            var result = translator.TranslateName(saveName);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestName_With_Dash()
        {
            // Arrange
            var saveName = "test-name";
            var expectedResult = "test_name";

            // Act
            var result = translator.TranslateName(saveName);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestName_With_Dash_And_Whitespaces()
        {
            // Arrange
            var saveName = "test -name";
            var expectedResult = "test__name";

            // Act
            var result = translator.TranslateName(saveName);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}