using System;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.XtraSpellChecker;
using log4net;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class SpellCheckerDictionaryManager
    {
        readonly ILog logger = LogManager.GetLogger(typeof(SpellCheckerDictionaryManager));        
        
        private SpellCheckerCustomDictionary customDictionary;

        public void LoadSpellCheckerDictionaries(SharedDictionaryStorage dictionaryStorage)
        {
            try
            {
                customDictionary = new SpellCheckerCustomDictionary();

                ISpellCheckerDictionary dictionary;

                if (Culture.IsFrench)
                {
                    // Note that the Open Office dictionary needs the dictionary and grammar files in
                    // MySpell format.  Open Office used to use MySpell before switching over to 
                    // Hunspell. Do not let the devex documentation fool you into thinking
                    // that Open Office uses just one format.
                    dictionary = BuildOpenOfficeDictionary("fr_FR_myspell.dic", "fr_FR_myspell.aff");
                    BuildAndAddCustomDictionary("CustomFrench.dic", "AlphabetFrench.txt");
                }
                else
                {
                    dictionary = BuildHunspellDictionary("en_US.dic", "en_US.aff");
                    BuildAndAddCustomDictionary("CustomEnglish.dic", "AlphabetEnglish.txt");
                }

                dictionaryStorage.Dictionaries.Add(dictionary);
                dictionaryStorage.Dictionaries.Add(customDictionary);
            }
            catch (Exception ex)
            {
                logger.Error("There was an error loading the spellchecker dictionaries", ex);
            }
        }

        private void BuildAndAddCustomDictionary(string dictionaryFile, string alphabetFile)
        {
            string customDictionaryFilePath = Path.Combine(Application.LocalUserAppDataPath, dictionaryFile);
            CreateCustomDictionaryFileIfNeeded(customDictionaryFilePath);
            customDictionary.Culture = Culture.CultureInfo;
            customDictionary.AlphabetPath = GetDictionaryPath(alphabetFile);
            customDictionary.DictionaryPath = customDictionaryFilePath;
        }

        private static SpellCheckerOpenOfficeDictionary BuildOpenOfficeDictionary(string dictionaryFile, string grammarFile)
        {
            SpellCheckerOpenOfficeDictionary dictionary = new SpellCheckerOpenOfficeDictionary();
            dictionary.DictionaryPath = GetDictionaryPath(dictionaryFile);
            dictionary.GrammarPath = GetDictionaryPath(grammarFile);
            dictionary.Culture = Culture.CultureInfo;
            dictionary.Load();
            return dictionary;
        }

        private static HunspellDictionary BuildHunspellDictionary(string dictionaryFile, string grammarFile)
        {
            HunspellDictionary dictionary = new HunspellDictionary();
            dictionary.DictionaryPath = GetDictionaryPath(dictionaryFile);
            dictionary.GrammarPath = GetDictionaryPath(grammarFile);
            dictionary.Culture = Culture.CultureInfo;
            dictionary.Load();
            return dictionary;
        }

        private static string GetDictionaryPath(string dictionary)
        {
            return Path.Combine(Application.StartupPath, dictionary);
        }

        private void CreateCustomDictionaryFileIfNeeded(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
            }
            catch (Exception e)
            {
                logger.Error("There was an error creating a file for the user spell checking dictionary.", e);
            }
        }
    }
}
