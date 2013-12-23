using System;

using MonoTouch.UIKit;

namespace SideBar
{
	public class SideBarSource : UITableViewSource
	{
		private const string CellId = "__SideBarCell__";
		private const float RowHeight = 45f;
		private readonly SideBarItemModel[] _rowData;

		public SideBarSource ()
		{
			_rowData = new SideBarItemModel[]
			{
				new SideBarItemModel { IconPath = "bookmark.png", Title = "Закладки" },
				new SideBarItemModel { IconPath = "calendar.png", Title = "Календарь" },
				new SideBarItemModel { IconPath = "comments.png", Title = "Комментарии" },
				new SideBarItemModel { IconPath = "map.png", Title = "Карта" },
				new SideBarItemModel { IconPath = "tag.png", Title = "Метки" },
				new SideBarItemModel { IconPath = "news.png", Title = "Новости" },
				new SideBarItemModel { IconPath = "photo.png", Title = "Фото" },
				new SideBarItemModel { IconPath = "wishlist.png", Title = "Покупки" }
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
	}
}

