namespace MusicalSequencer.Notes
{
    /// <summary>
    /// Maintains the dictionary that has notes and its frequency.
    /// </summary>
    public class MusicalNotes
    {
        /// <summary>
        /// Gets or sets the name of the note.
        /// </summary>
        /// <value>
        /// The name of the note.
        /// </value>
        public string NoteName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the frequency of the note.
        /// </summary>
        /// <value>
        /// The frequency of the note.
        /// </value>
        public int Frequency { get; set; } // Console.Beep takes only int as parameter.

        /// <summary>
        /// Gets or sets the duration of the note.
        /// </summary>
        /// <value>
        /// The duration of the note.
        /// </value>
        public int Duration { get; set; }
    }
}
