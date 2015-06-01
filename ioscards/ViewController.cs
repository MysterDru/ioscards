using System;

using UIKit;
using CoreGraphics;

namespace ioscards
{
    public partial class ViewController : UIViewController, L3SDKCardsViewDelegate
    {
        public UIButton MoreButton {get; set;}

        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

            this.AddCards();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public void AddCards()
        {
            this.AddCards(false);
        }

        void AddCards(bool drawView)
        {
            this.ContainerView.TheDelegate = this;
            L3SDKCard card;
            card = new L3SDKCard(new CGRect(0, 0, 0, 100));
            this.ContainerView.AddCardWithOptions(card, new L3SDKCardOptions { IsSwipable = true });
            card = new L3SDKCard(new CGRect(0, 0, 0, 150));
            this.ContainerView.AddCardWithOptions(card, new L3SDKCardOptions { IsSwipable = true });
            card = new L3SDKCard(new CGRect(0, 0, 0, 80));
            this.ContainerView.AddCardWithOptions(card, new L3SDKCardOptions { IsSwipable = true });
            card = new L3SDKCard(new CGRect(0, 0, 0, 120));
            this.ContainerView.AddCardWithOptions(card, new L3SDKCardOptions { IsSwipable = true });
            card = new L3SDKCard(new CGRect(0, 0, 0, 220));
            this.ContainerView.AddCardWithOptions(card, new L3SDKCardOptions { IsSwipable = true });
            this.MoreButton = new UIButton(UIButtonType.Custom);
            this.MoreButton = new UIButton(new CGRect(0, 0, this.ContainerView.Frame.Size.Width, 40));
            this.MoreButton.SetTitle("More", UIControlState.Normal);
            this.MoreButton.BackgroundColor = UIColor.White;
            this.MoreButton.SetTitleColor(UIColor.Gray, UIControlState.Normal);
            this.MoreButton.TitleLabel.Font = UIFont.ItalicSystemFontOfSize(16.0f);
            this.ContainerView.AddCard(this.MoreButton);
            if (drawView)
            {
                this.ContainerView.DrawView();
            }

        }

        nfloat GetAlphaHeader()
        {
            return this.ContainerView.Frame.Location.Y / this.ContainerView.ZeroFrame.Location.Y;
        }

        public void L3SDKCardsView_Scrolling(UISwipeGestureRecognizerDirection scrollDirection)
        {
            this.HeaderView.Alpha = this.GetAlphaHeader();
        }

        public void L3SDKCardsView_CardWillRemove(UIView view)
        {
            Console.WriteLine("card will remove");
        }

        public void L3SDKCardsView_CardDidlRemove(UIView view)
        {
            Console.WriteLine("card did remove");
            this.HeaderView.Alpha = this.GetAlphaHeader();
        }

        public void L3SDKCardsView_AllCardRemoved()
        {
            this.HeaderView.Alpha = 1;
        }

        public void L3SDKCardsView_UpperLimitReached()
        {
            this.HeaderView.Alpha = 0;
        }

        public void L3SDKCardsView_BottomLimitReached()
        {
            this.HeaderView.Alpha = 1;
        }
    }
}

