using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pelikula.WINUI.Helpers
{
    public static class FormHelper
    {
        public static void SelectAndShowDgvRow(DataGridView dgv, bool adding, int _currentIndex, int? _selectedRowIndex, List<FilterUtility.FilterParams> filters) {
            dgv.MultiSelect = false;

            if (adding) {
                dgv.FirstDisplayedScrollingRowIndex = dgv.RowCount - 1;
            }
            else if (_currentIndex >= 0 && _currentIndex < dgv.RowCount) {
                dgv.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (_currentIndex < 0 && dgv.RowCount > 0) {
                dgv.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding) {
                dgv.CurrentCell = dgv.Rows[dgv.RowCount - 1].Cells[1];
                dgv.Rows[dgv.RowCount - 1].Selected = true;
            }
            else if (filters.Count == 0 && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgv.RowCount) {
                dgv.CurrentCell = dgv.Rows[_selectedRowIndex.Value - 1].Cells[1];
                dgv.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (filters.Count == 0 && _selectedRowIndex.HasValue) {
                dgv.CurrentCell = dgv.Rows[_selectedRowIndex.Value].Cells[1];
                dgv.Rows[_selectedRowIndex.Value].Selected = true;
            }
            else if (dgv.RowCount > 0) {
                dgv.CurrentCell = dgv.Rows[0].Cells[1];
                dgv.Rows[0].Selected = true;
            }
        }

        public static void CreateFilters(List<FilterUtility.FilterParams> filters, TextBox txt, string columnName) {
            if (!string.IsNullOrEmpty(txt.Text))
                filters.Add(new FilterUtility.FilterParams(columnName, txt.Text, FilterUtility.FilterOptions.startswith.ToString()));

        }

        public static void CreateCbFilters(List<FilterUtility.FilterParams> filters, ComboBox cb, string columnName) {
            if (cb.SelectedItem != null && ((LoV)cb.SelectedItem).Id != -1)
                filters.Add(new FilterUtility.FilterParams(columnName, ((LoV)cb.SelectedItem).Id.ToString(), FilterUtility.FilterOptions.startswith.ToString()));

        }
    }
}
