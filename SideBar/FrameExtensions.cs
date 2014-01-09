using System;
using System.Drawing;

using MonoTouch.UIKit;

namespace Touch.Common
{
	public static class FrameExtensions
	{
		public static PointF GetTopRightCornerCoord(this UIView view)
		{
			PointF result = view.Frame.Location;
			result.X += view.Frame.Width;
			return result;
		}

		public static PointF GetBottomLeftCornerCoord(this UIView view)
		{
			PointF result = view.Frame.Location;
			result.Y += view.Frame.Height;
			return result;
		}

		public static PointF GetBottomRightCornerCoord(this UIView view)
		{
			PointF result = view.Frame.Location;
			result.Y += view.Frame.Height;
			result.X += view.Frame.Width;
			return result;
		}

		public static UIView AlignToRight(this UIView view)
		{
			return view.SetFrameX(view.Superview.Frame.Width - view.Frame.Width);
		}
		
		public static UIView AlignToBottom(this UIView view)
		{
			return view.SetFrameY(view.Superview.Frame.Height - view.Frame.Height);
		}

		public static UIView PlaceToLeftOf(this UIView view, UIView rightView, float margin = 0)
		{
			return view.SetFrameX(rightView.Frame.Left - view.Frame.Width - margin);
		}
		
		public static UIView PlaceToRightOf(this UIView view, UIView leftView, float margin = 0)
		{
			return view.SetFrameX(leftView.Frame.Right + margin);
		}
		
		public static UIView SetCenterPosition(this UIView view, float x, float y)
		{
			return view.SetFrame(x - view.Frame.Width / 2, y - view.Frame.Height / 2, view.Frame.Width, view.Frame.Height);
		}

		public static UIView SetLocation(this UIView view, PointF position)
		{
			return view.SetFrame(position.X, position.Y, view.Frame.Width, view.Frame.Height);
		}

		public static UIView SetLocation(this UIView view, float x, float y)
		{
			return view.SetFrame(x, y, view.Frame.Width, view.Frame.Height);
		}

		public static UIView MoveVertically(this UIView view, float dy)
		{
			RectangleF frame = view.Frame;
			view.SetFrame(frame.X, frame.Y + dy, frame.Width, frame.Height);

			return view;
		}

		public static UIView Move(this UIView view, PointF shift)
		{
			PointF location = view.Frame.Location;
			location.X += shift.X;
			location.Y += shift.Y;

			view.Frame = new RectangleF(location, view.Frame.Size);

			return view;
		}

		public static UIView MoveHorizontaly(this UIView view, float dx)
		{
			RectangleF frame = view.Frame;
			view.SetFrame(frame.X + dx, frame.Y, frame.Width, frame.Height);
			
			return view;
		}
		
		public static UIView PlaceBelow(this UIView view, UIView viewAbove, float margin = 0)
		{
			return view.SetFrameY(viewAbove.Frame.Bottom + margin);
		}
		
		public static UIView SetMaskCenter(this UIView view)
		{
			view.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
			return view;
		}
		
		public static UIView SetLabelSize(this UILabel label, float maxWidth)
		{
			var size = label.StringSize(label.Text ?? "", label.Font, maxWidth, UILineBreakMode.TailTruncation);
			return label.SetFrame(0, 0, size.Width + 2f, size.Height);
		}
		
		public static UIView SetSizeFromScaledFrame(this UIView view, RectangleF frame, float scale)
		{
			var width = frame.Width * scale;
			var height = frame.Height * scale;
			
			return view.SetFrame((frame.Width - width) / 2, (frame.Height - height) / 2, width, height);
		}
		
		public static UIView SetSize(this UIView view, SizeF size)
		{
			return view.SetSize(size.Width, size.Height);
		}
		
		public static UIView SetSizeToImage(this UIImageView view)
		{
			return view.SetSize(view.Image.Size);
		}
		
		public static UIView SetSize(this UIView view, float width, float height)
		{
			view.Frame = new RectangleF(
				view.Frame.X,
				view.Frame.Y,
				width,
				height).Strict();
			
			return view;
		}
		
		public static UIView FillAbove(this UIView view, UIView relativeView)
		{
			view.Frame = new RectangleF(
				0,
				0,
				view.Superview.Frame.Width,
				relativeView.Frame.Y).Strict();
			
			return view;
		}
		
		public static UIView FillAbove(this UILabel view, UIView relativeView)
		{
			view.Frame = new RectangleF(
				0,
				0,
				view.Superview.Frame.Width,
				relativeView.Frame.Y).Strict();
			
			return view;
		}
		
		public static UIView FillBelow(this UIView view, UIView relativeView)
		{
			view.Frame = new RectangleF(
				0,
				relativeView.Frame.Bottom,
				view.Superview.Frame.Width,
				view.Superview.Frame.Height - relativeView.Frame.Bottom).Strict();
			
			return view;
		}

		public static PointF GetCenter(this RectangleF frame)
		{
			PointF center = new PointF(frame.Width / 2.0f, frame.Height / 2.0f);

			return center;
		}

		public static PointF GetCenter(this UIView view)
		{
			return GetCenter(view.Frame);
		}

		public static PointF GetCenterFromBounds(this UIView view)
		{
			return GetCenter(view.Bounds);
		}

		public static UIView CenterInParent(this UIView view)
		{
			view.Frame = new RectangleF(
				(view.Superview.Frame.Width - view.Frame.Width) / 2,
				(view.Superview.Frame.Height - view.Frame.Height) / 2,
				view.Frame.Width,
				view.Frame.Height).Strict();
			
			return view;
		}
		
		// Нужно для редких случаев когда вью распологается относительно НЕ родительской. См. где используется для понимания
		public static UIView CenterRelativeTo(this UIView view, UIView relativeView)
		{
			view.Frame = new RectangleF(
				(relativeView.Frame.Width - view.Frame.Width) / 2,
				(relativeView.Frame.Height - view.Frame.Height) / 2,
				view.Frame.Width,
				view.Frame.Height).Strict();
			
			return view;
		}
		
		public static UIView CenterVertically(this UIView view, float topMargin = 0f)
		{
			view.Frame = new RectangleF(
				view.Frame.X,
				(view.Superview.Frame.Height - view.Frame.Height + topMargin) / 2,
				view.Frame.Width,
				view.Frame.Height).Strict();
			
			return view;
		}
		
		public static UIView CenterHorizontally(this UIView view)
		{
			view.Frame = new RectangleF(
				(view.Superview.Frame.Width - view.Frame.Width) / 2,
				view.Frame.Y,
				view.Frame.Width,
				view.Frame.Height).Strict();
			
			return view;
		}
		
		public static UIView CenterHorizontally(this UIView view, UIView relativeTo)
		{
			view.Frame = new RectangleF(
				relativeTo.Frame.X + (relativeTo.Frame.Width - view.Frame.Width) / 2,
				view.Frame.Y,
				view.Frame.Width,
				view.Frame.Height).Strict();
			
			return view;
		}
		
		/// <summary>
		/// TopMargin - расстояние между верхним краем view и верхним краем родителя
		/// </summary>
		public static UIView SetTopMargin(this UIView view, float topMargin)
		{
			return view.SetTopMargin(view.Superview, topMargin);
		}
		
		/// <summary>
		/// TopMargin - расстояние между верхним краем view и верхним краем родителя
		/// </summary>
		public static UIView SetTopMargin(this UIView view, UIView relativeView, float topMargin)
		{
			view.Frame = new RectangleF(
				view.Frame.X,
				topMargin,
				view.Frame.Width,
				view.Frame.Height).Strict();
			
			return view;
		}
		
		/// <summary>
		/// BottomMargin - расстояние между нижним краем view и нижним краем родителя
		/// </summary>
		public static UIView SetBottomMargin(this UIView view, float bottomMargin)
		{
			return view.SetBottomMargin(view.Superview, bottomMargin);
		}
		
		/// <summary>
		/// BottomMargin - расстояние между нижним краем view и нижним краем родителя
		/// </summary>
		public static UIView SetBottomMargin(this UIView view, UIView relativeView, float bottomMargin)
		{
			view.Frame = new RectangleF(
				view.Frame.X,
				relativeView.Frame.Height - view.Frame.Height - bottomMargin,
				view.Frame.Width,
				view.Frame.Height).Strict();
			
			return view;
		}
		
		public static UIView SetFrame(this UIView view, float x, float y, float width, float height)
		{
			view.Frame = new RectangleF(
				x,
				y,
				width,
				height).Strict();
			
			return view;
		}
		
		public static UIView SetFrameX(this UIView view, float x)
		{
			view.Frame = new RectangleF(
				x,
				view.Frame.Y,
				view.Frame.Width,
				view.Frame.Height).Strict();
			
			return view;
		}
		
		public static UIView SetFrameY(this UIView view, float y)
		{
			view.Frame = new RectangleF(
				view.Frame.X,
				y,
				view.Frame.Width,
				view.Frame.Height).Strict();
			
			return view;
		}
		
		public static UIView SetWidth(this UIView view, float width)
		{
			view.Frame = new RectangleF(
				view.Frame.X,
				view.Frame.Y,
				width,
				view.Frame.Height).Strict();
			
			return view;
		}
		
		public static UIView SetHeight(this UIView view, float height)
		{
			view.Frame = new RectangleF(
				view.Frame.X,
				view.Frame.Y,
				view.Frame.Width,
				height).Strict();
			
			return view;
		}
		
		public static RectangleF Strict(this RectangleF rect)
		{
			return new RectangleF(
				(int)rect.X,
				(int)rect.Y,
				(int)rect.Width,
				(int)rect.Height
				);	
			
		}
		
		public static PointF CalcCoordinatesRelativeToAncestor(this UIView view, UIView ancestor)
		{
			if (ancestor == null)
			{
				throw new ArgumentNullException("ancestor couldn't be null");
			}
			if (view == null)
			{
				throw new ArgumentNullException("view couldn't be null");
			}
			if (ancestor == view)
			{
				throw new ArgumentException("ancestor and view are equal");
			}
			
			float x = view.Frame.X;
			float y = view.Frame.Y;
			
			UIView parent = view.Superview;
			while (parent != ancestor && parent != null)
			{
				x += parent.Frame.X;
				y += parent.Frame.Y;
				
				parent = parent.Superview;
			}
			
			if (parent == null)
			{
				throw new ArgumentException("ancestor is not ancestor for view");
			}
			
			return new PointF(x, y);
		}
		
		public static PointF CalcCoordinatesRelativeToDescendant(this UIView view, UIView descendant)
		{
			UIView parent = view.Superview;
			PointF descendantCoordinatesrelativeToParent = descendant.CalcCoordinatesRelativeToAncestor(parent);
			
			float x = view.Frame.X - descendantCoordinatesrelativeToParent.X;
			float y = view.Frame.Y - descendantCoordinatesrelativeToParent.Y;
			
			return new PointF(x, y);
		}
		
		public static void BubbleViewToAncestor(this UIView view, UIView ancestor)
		{
			PointF coordinates = view.CalcCoordinatesRelativeToAncestor(ancestor);
			
			float width = view.Frame.Width;
			float height = view.Frame.Height;
			
			view.RemoveFromSuperview();
			view.Frame = new RectangleF(coordinates.X, coordinates.Y, width, height);
			ancestor.AddSubview(view);
		}
		
		public static void TunnellingViewToDescendant(this UIView view, UIView descendant)
		{
			PointF coords = view.CalcCoordinatesRelativeToDescendant(descendant);
			
			float h = view.Frame.Height;
			float w = view.Frame.Width;
			
			view.RemoveFromSuperview();
			view.Frame = new RectangleF(coords.X, coords.Y, h, w);
			descendant.AddSubview(view);
		}
	}
}

