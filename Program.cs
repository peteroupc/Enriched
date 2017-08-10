/*
Written by Peter O. in 2014.
Any copyright is dedicated to the Public Domain.
http://creativecommons.org/publicdomain/zero/1.0/
If you like this, you should donate to Peter O.
at: http://peteroupc.github.io/
 */
using System;
using System.IO;
using PeterO.Enriched;
using PeterO.Text;

namespace Enriched {
    /// <summary>Not documented yet.</summary>
    internal class Program {
    /// <summary>Not documented yet.</summary>
    /// <param name='filename'>The parameter <paramref name='filename'/> is
    /// not documented yet.</param>
    /// <returns>A string object.</returns>
        public static string ReadTextFromFile(string filename) {
             using (var stream = new FileStream(filename, FileMode.Open)) {
                return new CharacterReader(stream, 2).InputToString();
            }
        }

    /// <summary>Not documented yet.</summary>
    /// <param name='args'>The parameter <paramref name='args'/> is not
    /// documented yet.</param>
        public static void Main(string[] args) {
            if (args.Length < 2) {
             Console.WriteLine("Usage: Enriched <input-enriched-text-file> " +
                    "<output-html-file>" + Environment.NewLine +
  "Supports files encoded in UTF-8, UTF-16, or UTF-32. Files" +
                    Environment.NewLine +
  "that use the latter two encodings should have a byte-order" +
                    Environment.NewLine + "mark at the beginning.");
                return;
            }
            string input = args[0];
            string output = args[1];
            if (!File.Exists(input)) {
                Console.WriteLine("File not found: " + input);
                return;
            }
            string text = ReadTextFromFile(input);
            text = EnrichedText.EnrichedToHtml(text, 0, text.Length);
            File.WriteAllText(output, text);
        }
    }
}
