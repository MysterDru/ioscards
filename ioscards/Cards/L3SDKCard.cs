using System;
using UIKit;
using CoreGraphics;

namespace ioscards
{
    public class L3SDKCard : UIView, IUIGestureRecognizerDelegate //, UIGestureRecognizerDelegate
    {
        public CGRect ZeroFrame { get; set; }

        public L3SDKCard(CGRect frame)
            : base(frame)
        {
            this.DrawRect(frame);
        }

        void DrawRect(CGRect rect)
        {
            UIBezierPath shadowPath = UIBezierPath.FromRect(this.Bounds);
            this.ZeroFrame = this.Frame;
            this.Layer.MasksToBounds = false;
            this.Layer.ShadowColor = UIColor.Black.CGColor;
            this.Layer.ShadowOffset = new CGSize(0.0f, 1.0f);
            this.Layer.ShadowOpacity = 0.5f;
            this.Layer.ShadowPath = shadowPath.CGPath;
            this.BackgroundColor = UIColor.White;
        }
    }
}