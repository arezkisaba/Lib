using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Core.UnitTests
{
    [TestClass]
    public class StringExtensionsUnitTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void ContainsIgnoreCase_TestMethod()
        {
            var result = "paSsé".ContainsIgnoreCase("ssé");
            Assert.IsTrue(result);

            result = "paSsé".ContainsIgnoreCase("tsé");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IndexOfIgnoreCase_TestMethod()
        {
            var result = "paSsé".IndexOfIgnoreCase("ssé");
            Assert.IsTrue(result == 2);

            result = "paSsé".IndexOfIgnoreCase("tsé");
            Assert.IsTrue(result == -1);
        }

        [TestMethod]
        public void EndsWithIgnoreCase_TestMethod()
        {
            var result = "paSsé".EndsWithIgnoreCase("ssé");
            Assert.IsTrue(result);

            result = "paSsé".EndsWithIgnoreCase("tsé");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StartsWithIgnoreCase_TestMethod()
        {
            var result = "éLéphant".StartsWithIgnoreCase("ele");
            Assert.IsTrue(result);

            result = "éLéphant".StartsWithIgnoreCase("ela");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Clean_TestMethod()
        {
            var text = "[sdfsdf]lLWL#DsZ5(qsd)z:63+6".Clean();
            Assert.IsTrue(text == "lLWLDsZ5z636");
        }

        [TestMethod]
        public void RemoveFirstCharacter_TestMethod()
        {
            var text = "Thor".RemoveFirstCharacter();
            Assert.IsTrue(text == "hor");
        }

        [TestMethod]
        public void RemoveLastCharacter_TestMethod()
        {
            var text = "Thor".RemoveLastCharacter();
            Assert.IsTrue(text == "Tho");
        }

        [TestMethod]
        public void RemoveAccents_TestMethod()
        {
            var text = "J'ai été à l'arrêt près de là où habitent Moïse et Gwenaëlle".ReplaceAccentsByOriginalLetters();
            Assert.IsTrue(text == "J'ai ete a l'arret pres de la ou habitent Moise et Gwenaëlle");
        }

        [TestMethod]
        public void RemoveBracketsContent_TestMethod()
        {
            var text = "[Cpasbien]Thor".RemoveBracketsContent();
            Assert.IsTrue(text == "Thor");
        }

        [TestMethod]
        public void RemoveParenthesisContent_TestMethod()
        {
            var text = "Thor(2011)".RemoveParenthesisContent();
            Assert.IsTrue(text == "Thor");
        }

        [TestMethod]
        public void RemoveHtml_TestMethod()
        {
            var text = "<span class='blue'>Thor</span> <span class='blue'>FRENCH</span> DVDRIP 2011".RemoveHtml();
            Assert.IsTrue(text == "Thor FRENCH DVDRIP 2011");
        }

        [TestMethod]
        public void RemoveDoubleSpacesAndTrim_TestMethod()
        {
            var text = "  Star    Wars  ".RemoveDoubleSpacesAndTrim();
            Assert.IsTrue(text == "Star Wars");
        }

        [TestMethod]
        public void RemoveSpecialCharacters_TestMethod()
        {
            var text = "lLWL#DsZ5z:63+6".RemoveSpecialCharacters();
            Assert.IsTrue(text == "lLWLDsZ5z636");
        }

        [TestMethod]
        public void TransformForStorage_TestMethod()
        {
            var text = "  Star  Wars //    :   L'Ascenscion de   <Skywalker   > ".TransformForStorage();
            Assert.IsTrue(text == "Star Wars L'Ascenscion de Skywalker");
        }
    }
}
