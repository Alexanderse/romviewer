using System.Collections;
using System.ComponentModel;

namespace RomViewer
{
    public class BindingListEx<T> : BindingList<T>
    {
        private SorterEx<T> m_Sorter = new SorterEx<T>();

        protected override bool SupportsSortingCore
        {
            get { return _SupportsSortingCore; }
        }

        private bool _SupportsSortingCore = true;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>();
            T[] tArr = new T[this.Count];

            this.CopyTo(tArr, 0);

            foreach (T t in tArr)
                list.Add(t);

            m_Sorter.PropertyToSortOn = prop;
            m_Sorter.Direction = direction;
            list.Sort(m_Sorter);

            this.Clear();

            foreach (T item in list)
            {
                this.Add(item);
            }

        }

        public void Sort(PropertyDescriptor prop, ListSortDirection direction)
        {
            this.ApplySortCore(prop, direction);
        }

    }

    public class SorterEx<T> : System.Collections.Generic.IComparer<T>
    {
        private CaseInsensitiveComparer ObjectCompare;

        public SorterEx()
        {
            ObjectCompare = new CaseInsensitiveComparer();
        }

        public ListSortDirection Direction
        {
            get { return m_Direction; }
            set { m_Direction = value; }
        }

        private ListSortDirection m_Direction = ListSortDirection.Ascending;

        public PropertyDescriptor PropertyToSortOn
        {
            get { return m_PropertyToSortOn; }

            set { m_PropertyToSortOn = value; }
        }

        private PropertyDescriptor m_PropertyToSortOn;

        public int Compare(T itemX, T itemY)
        {
            int compareResult;

            string valueX;
            string valueY;

            valueX = m_PropertyToSortOn.GetValue(itemX).ToString();
            valueY = m_PropertyToSortOn.GetValue(itemY).ToString();

            compareResult = ObjectCompare.Compare(valueX, valueY);

            if (m_Direction == ListSortDirection.Ascending)
            {
                return compareResult;
            }
            else
            {
                return (-compareResult);
            }
        }
    }
}


 