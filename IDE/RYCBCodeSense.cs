using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using IDE.Properties;
using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IDE
{
    internal class RYCBCodeSense : ICompletionData
    {
        private CodeSenseType _type;

        public RYCBCodeSense(string text, CodeSenseType type, string desc)
        {
            this.Text = text;
            this._type = type;
            this.Description = desc;
        }

        public ImageSource Image => _type switch
        {
            CodeSenseType.FIELD => Imaging.CreateBitmapSourceFromHBitmap(Resources.field.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
            CodeSenseType.FUNC => Imaging.CreateBitmapSourceFromHBitmap(Resources.func.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
            CodeSenseType.KEYWORD => Imaging.CreateBitmapSourceFromHBitmap(Resources.keyword.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
            _ => Imaging.CreateBitmapSourceFromHBitmap(Resources.help.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
        };

        public string Text { get; set; }

        public object Content => this.Text;

        public object Description { get; set; }

        public double Priority { get; }

        public void Complete(TextArea textArea, ISegment completionSegment, EventArgs insertionRequestEventArgs)
        {
            textArea.Document.Replace(completionSegment, Text);
        }
    }
}
