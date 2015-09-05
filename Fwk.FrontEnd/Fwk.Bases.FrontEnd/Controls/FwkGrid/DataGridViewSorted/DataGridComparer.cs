using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using System.ComponentModel;
using System.Diagnostics;


	#region Data Grid Column Comparer

	public class DataGridComparer : System.Collections.IComparer
	{
		DataGridView _grid;
		List<SortColDefn> _sortedColumns;
		int _maxSortColumns;

		private struct SortColDefn
		{
			internal Int16 colNum;
			internal bool ascending;

			internal SortColDefn(int columnNum, SortOrder sortOrder)
			{
				colNum = Convert.ToInt16(columnNum);
				ascending = (sortOrder != SortOrder.Descending);
			}
		}


        public void ClearSortCol()
        {
            _sortedColumns.Clear();

        }

		public DataGridComparer(DataGridView datagrid)
		{
			_grid = datagrid;

			// No limit by default to the number of columns sorted.
			_maxSortColumns = 0;

			_sortedColumns = new List<SortColDefn>(_maxSortColumns);
		}

		public int MaxSortColumns
		{
			get { return _sortedColumns.Capacity; }
			set
			{
				if (_sortedColumns.Count > value)
					_sortedColumns.RemoveRange(value - 1, _sortedColumns.Count);

				_sortedColumns.Capacity = value;
			}
		}

		public SortOrder SetSortColumn(int columnIndex, Keys ModifierKeys)
		{
			bool keepSamePriority = ((ModifierKeys & Keys.Control) == Keys.Control);
			SortColDefn colDefn;

			if (_sortedColumns.Count > 0 && !keepSamePriority)
			{
				// Erase the current sort glyph.
				colDefn = _sortedColumns[0];
				_grid.Columns[colDefn.colNum].HeaderCell.SortGlyphDirection = SortOrder.None;
			}

			int sortPriority = _sortedColumns.FindIndex(
				delegate(SortColDefn cd) { return cd.colNum == columnIndex; });

			if (sortPriority != -1)
				return ReverseSort(keepSamePriority, sortPriority);

			// Column not found in list.
			// This column is not being sorted at present.

			// If got to limit of num sorted columns, remove the current last one.
			if (_maxSortColumns > 0 && _sortedColumns.Count == _sortedColumns.Capacity)
				_sortedColumns.RemoveAt(_sortedColumns.Count - 1);

			colDefn = new SortColDefn(columnIndex, SortOrder.Ascending);
			if (keepSamePriority)
			{
				_sortedColumns.Add(colDefn);
				if (_sortedColumns.Count > 1)
					return SortOrder.Ascending; // Do not set the glyph.
			}
			else
				_sortedColumns.Insert(0, colDefn);

			_grid.Columns[colDefn.colNum].HeaderCell.SortGlyphDirection = SortOrder.Ascending;

			return SortOrder.Ascending;
		}

		private SortOrder ReverseSort(bool keepSamePriority, int sortPriority)
		{
			SortColDefn colDefn = _sortedColumns[sortPriority];

			// The column is already being sorted.
			SortOrder sortOrder;
			if (sortPriority == 0 || keepSamePriority)
			{
				// There is no need to change where it is in the list.
				colDefn.ascending = !colDefn.ascending;
				_sortedColumns[sortPriority] = colDefn;

				sortOrder = colDefn.ascending ? SortOrder.Ascending : SortOrder.Descending;
				if (sortPriority != 0)
					return sortOrder; // Reverse only, do not set the glyph.
			}
			else
			{
				// Promote this column to be the first.
				for (int loop = sortPriority; loop > 0; --loop)
				{
					_sortedColumns[loop] = _sortedColumns[loop - 1];
				}
				// Promoted columns are always sorted ascending.
				colDefn.ascending = true;
				_sortedColumns[0] = colDefn;
				sortOrder = SortOrder.Ascending;
			}
			_grid.Columns[colDefn.colNum].HeaderCell.SortGlyphDirection = sortOrder;

			return sortOrder;
		}

		public string SortOrderDescription
		{
			get
			{
				StringBuilder sb = new StringBuilder("Sorted by ");

				foreach (SortColDefn colDefn in _sortedColumns)
				{
					//sb.Append(colDefn.colNum);
					//sb.Append(':');
					sb.Append(_grid.Columns[colDefn.colNum].HeaderText);
					sb.Append(colDefn.ascending ? " ASC, " : " DESC, ");
				}

				sb.Length -= 2;

				return sb.ToString();
			}
            
		}

		public int Compare(DataGridViewCellCollection lhs, DataGridViewCellCollection rhs)
		{
			foreach (SortColDefn colDefn in _sortedColumns)
			{
				int retval = Comparer<object>.Default.Compare(
					lhs[colDefn.colNum].Value,
					rhs[colDefn.colNum].Value);

				if (retval != 0)
					return (colDefn.ascending ? retval : -retval);
			}

			// These two rows are indistinguishable.
			return 0;
		}

		#region IComparer Members

		public int Compare(object x, object y)
		{
			DataGridViewRow lhs = x as DataGridViewRow;
			DataGridViewRow rhs = y as DataGridViewRow;

			return Compare(lhs.Cells, rhs.Cells);
		}

		#endregion
	}

	#endregion
