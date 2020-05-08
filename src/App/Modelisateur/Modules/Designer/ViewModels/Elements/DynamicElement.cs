using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Modelisateur.Modules.Designer.ViewModels.Elements
{
    public abstract class DynamicElement : ElementViewModel
    {
        protected DynamicElement()
        {
            //AddOutputConnector("Output", Colors.DarkSeaGreen, () => PreviewImage);
        }

        protected virtual void PrepareDrawingVisual(DrawingVisual drawingVisual)
        {
            
        }

        protected abstract void Draw(DrawingContext drawingContext, Rect bounds);

        protected void UpdatePreview()
        {
            var dv = new DrawingVisual();
            PrepareDrawingVisual(dv);

            DrawingContext dc = dv.RenderOpen();
            Draw(dc, new Rect(0, 0, PreviewWidth, PreviewHeight));
            dc.Close();

            //var rtb = new RenderTargetBitmap((int) PreviewWidth, (int) PreviewHeight, 96, 96, PixelFormats.Pbgra32);
            //rtb.Render(dv);

            if (dv.Effect is IDisposable)
                ((IDisposable) dv.Effect).Dispose();

            //_previewImage = rtb;
            //NotifyOfPropertyChange("PreviewImage");

            //RaiseOutputChanged();
        }

        protected override void OnInputConnectorSourceChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }
    }
}