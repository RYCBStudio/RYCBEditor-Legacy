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
        private int cstrl = 0;
        internal static bool _completed = false;

        public RYCBCodeSense(string text, CodeSenseType type, string desc)
        {
            this.Text = text;
            this._type = type;
            this.Description = desc;
        }

        public RYCBCodeSense(string text, int completionStrLength, CodeSenseType type)
        {
            switch (type)
            {
                case CodeSenseType.FIELD:
                    this.Text = text;
                    this._type = type;
                    this.Description = $"FIELD {text}";
                    this.cstrl = completionStrLength;
                    break;
                case CodeSenseType.FUNC:
                    this.Text = text;
                    this._type = type;
                    this.Description = $"FUNC {text}";
                    this.cstrl = completionStrLength;
                    break;
                case CodeSenseType.KEYWORD:
                    this.Text = text;
                    this._type = type;
                    this.Description = $"KEYWORD {text}";
                    this.cstrl = completionStrLength;
                    break;
                case CodeSenseType.BUILTIN:
                    this.Text = text;
                    this._type = type;
                    this.Description = $"BUILTIN {text}";
                    this.cstrl = completionStrLength;
                    break;
                default:
                    break;
            }
        }

        public ImageSource Image => _type switch
        {
            CodeSenseType.FIELD => Imaging.CreateBitmapSourceFromHBitmap(Resources.field.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
            CodeSenseType.FUNC => Imaging.CreateBitmapSourceFromHBitmap(Resources.func.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
            CodeSenseType.KEYWORD => Imaging.CreateBitmapSourceFromHBitmap(Resources.keyword.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
            CodeSenseType.BUILTIN => Imaging.CreateBitmapSourceFromHBitmap(Resources.builtin.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
            _ => Imaging.CreateBitmapSourceFromHBitmap(Resources.help.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()),
        };

        public string Text
        {
            get; set;
        }

        public object Content => this.Text;

        public object Description
        {
            get; set;
        }

        public double Priority
        {
            get;
        }

        public static void Clear(ref string _)
        {
            if (_completed)
            {
                _ = "";
            }
        }

        public void Complete(TextArea textArea, ISegment completionSegment, EventArgs insertionRequestEventArgs)
        {
            var completionText = Text.Substring(completionSegment.Length);
            textArea.Document.Insert(textArea.Caret.Offset, completionText);
            _completed = true;
        }
    }
}
