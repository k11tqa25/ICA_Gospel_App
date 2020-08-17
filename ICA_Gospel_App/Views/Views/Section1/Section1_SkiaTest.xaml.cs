using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICA_Gospel_App.Views
{
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class Section1_SkiaTest : NavigatableView
        {
                public Section1_SkiaTest()
                {
                        InitializeComponent();
                }
                
                private void Section_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
                {
                        SKImageInfo info = e.Info;
                        SKSurface surface = e.Surface;
                        SKCanvas canvas = surface.Canvas;

                        canvas.Clear();

                        double wid = DeviceDisplay.MainDisplayInfo.Width;
                        double hei = DeviceDisplay.MainDisplayInfo.Height;

                        // get density
                        float density = info.Size.Width / (float)this.Width;

                        DrawSvgAtPoint(canvas, new SKPoint(0,0), new Size(wid, hei), "ICA_Gospel_App.SVGs.Section1.S1E1.svg");

                }

                private void DrawSvgAtPoint(SKCanvas canvas, SKPoint location, Size size, string svgName)
                {
                        // load up the SVG
                        using (Stream stream = GetType().Assembly.GetManifestResourceStream(svgName))
                        {
                                SkiaSharp.Extended.Svg.SKSvg svg = new SkiaSharp.Extended.Svg.SKSvg();
                                svg.Load(stream);

                                using (new SKAutoCanvasRestore(canvas))
                                {
                                        SKRect bounds = svg.ViewBox;

                                        float xRatio = (float)size.Width / bounds.Width;
                                        float yRatio = (float)size.Height / bounds.Height;

                                        var matrix = SKMatrix.CreateScale(xRatio, yRatio);

                                        // render the image
                                        canvas.DrawPicture(svg.Picture, ref matrix);
                                }
                        }
                }

        }
}