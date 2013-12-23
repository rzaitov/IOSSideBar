using System;

using MonoTouch.UIKit;

namespace SideBar
{
	public class SideBarSource : UITableViewSource
	{
		public event Action<SideBarItemModel> RowSelectedEvent;

		private const string CellId = "__SideBarCell__";
		private const float RowHeight = 45f;
		private readonly SideBarItemModel[] _rowData;

		public SideBarSource ()
		{
			_rowData = new SideBarItemModel[]
			{
				new SideBarItemModel { IconPath = "bookmark.png", Title = "Закладки", Type = MenuType.Bookmark },
				new SideBarItemModel { IconPath = "calendar.png", Title = "Календарь", Type = MenuType.Calendar },
				new SideBarItemModel { IconPath = "comments.png", Title = "Комментарии", Type = MenuType.Comments },
				new SideBarItemModel { IconPath = "map.png", Title = "Карта", Type = MenuType.Map },
				new SideBarItemModel { IconPath = "tag.png", Title = "Метки", Type = MenuType.Tag },
				new SideBarItemModel { IconPath = "news.png", Title = "Новости", Type = MenuType.News },
				new SideBarItemModel { IconPath = "photo.png", Title = "Фото", Type = MenuType.Photo },
				new SideBarItemModel { IconPath = "wishlist.png", Title = "Покупки", Type = MenuType.Wishlist }
			};
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _rowData.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			int row = indexPath.Row;
			SideBarItemModel rowModel = _rowData [row];

			SideBarCell cell = tableView.DequeueReusableCell (CellId) as SideBarCell;
			cell = cell ?? new SideBarCell ();

			cell.InitWithModel (rowModel);

			return cell;
		}

		public override float GetHeightForRow (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			return RowHeight;
		}

		public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			SideBarItemModel model = _rowData [indexPath.Row];

			var handler = RowSelectedEvent;
			if (handler != null)
			{
				handler(model);
			}
		}
	}
}

