using System;
using Windows.Media.SpeechRecognition;
using System.Text;
using System.Diagnostics;

namespace Kophosight
{
    public static partial class SpeechRecognition
    {
        private static SpeechRecognizer speechRecognizer = new SpeechRecognizer();
        private static StringBuilder dictatedTextBuilder = new StringBuilder();
        public static String key = "00";
        //public static Stopwatch timer = new Stopwatch();
        public static String[] keys;
        public static int hypothesize = 0;
        public static String lastKey = "";
        static Char[] separator = { ' ' };


        public static async void onStart()
        {
            var storageFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///GrammarFileConstraint.grxml"));
            var grammarFileConstraint = new SpeechRecognitionGrammarFileConstraint(storageFile, "colors");

            speechRecognizer.Constraints.Add(grammarFileConstraint);
            SpeechRecognitionCompilationResult result = await speechRecognizer.CompileConstraintsAsync();
            Debug.WriteLine("result compilation :"+result.Status.ToString());
            speechRecognizer.StateChanged += onStateChanged;
            speechRecognizer.HypothesisGenerated += speechRecognizer_HypothesisGenerated;
            if (speechRecognizer.State == SpeechRecognizerState.Idle)
            {
                await speechRecognizer.ContinuousRecognitionSession.StartAsync();
            }
            //System.Diagnostics.Debug.WriteLine("Speech recognition started");
        }

        static async void onStateChanged(SpeechRecognizer sender, SpeechRecognizerStateChangedEventArgs args)
        {
            if (args.State.ToString() == "SpeechDetected")
            {
               // timer.Restart();
              //  Debug.WriteLine("key recognition timer restarted");
            }
        }

        static async void speechRecognizer_HypothesisGenerated(SpeechRecognizer sender, SpeechRecognitionHypothesisGeneratedEventArgs args)
        {

            //Debug.WriteLine("\nHypothesize :" + hypothesize);
           // Debug.WriteLine("args length :" + args.Hypothesis.Text.Length);
          //  Debug.WriteLine(args.Hypothesis.Text);
            if (hypothesize != args.Hypothesis.Text.Length)
            {
                keys = args.Hypothesis.Text.Split(separator);
                lastKey = keys[keys.Length - 1];
               // Debug.WriteLine("lastKey :" + lastKey);
            }
            else
            {
               // Debug.WriteLine("Doublon d'hypothèse");
            }
            hypothesize = args.Hypothesis.Text.Length;
            key = lastKey;
            keyDependet.key = key;
           // Debug.WriteLine("Recognised key = " + key);
          //  Debug.WriteLine("Key recognition speed = " + timer.ElapsedMilliseconds + " ms");
        }

        public static async void onStop()
        {
            await speechRecognizer.ContinuousRecognitionSession.CancelAsync();
        }
    }
}