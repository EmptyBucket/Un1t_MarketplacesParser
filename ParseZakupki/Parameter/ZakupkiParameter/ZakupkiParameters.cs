using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ParseZakupki.Parameter
{
    public class ZakupkiParameters : IReadOnlyDictionary<IParameterType, Parameter>, ICloneable, IParameters
    {
        public const int MaxRecordsPerPage = 500;

        private Dictionary<IParameterType, Parameter> mParameters = new Dictionary<IParameterType, Parameter>();

        private int mPageNumber;
        public int PageNumber
        {
            get
            {
                return mPageNumber;
            }
            set
            {
                mPageNumber = value;
                mParameters[ZakupkiParameterType.PageNumber] = new Parameter(ZakupkiParameterType.PageNumber, value.ToString());
            }
        }
        private int mRecordsPerPage;
        public int RecordsPerPage
        {
            get
            {
                return mRecordsPerPage;
            }
            set
            {
                mRecordsPerPage = value;
                mParameters[ZakupkiParameterType.RecordsPerPage] = new Parameter(ZakupkiParameterType.RecordsPerPage, '_' + value.ToString());
            }
        }
        private long mCostFrom;
        public long CostFrom
        {
            get
            {
                return mCostFrom;
            }
            set
            {
                mCostFrom = value;
                mParameters[ZakupkiParameterType.PriceFrom] = new Parameter(ZakupkiParameterType.PriceFrom, value.ToString());
            }
        }
        private long mCostTo;
        public long CostTo
        {
            get
            {
                return mCostTo;
            }
            set
            {
                mCostTo = value;
                mParameters[ZakupkiParameterType.PriceTo] = new Parameter(ZakupkiParameterType.PriceTo, value.ToString());
            }
        }
        private DateTime mPublishDateFrom;
        public DateTime PublishDateFrom
        {
            get
            {
                return mPublishDateFrom;
            }
            set
            {
                mPublishDateFrom = value;
                mParameters[ZakupkiParameterType.PublishDateFrom] = new Parameter(ZakupkiParameterType.PublishDateFrom, value.ToString("d"));
            }
        }
        private DateTime mPublishDateTo;
        public DateTime PublishDateTo
        {
            get
            {
                return mPublishDateTo;
            }
            set
            {
                mPublishDateTo = value;
                mParameters[ZakupkiParameterType.PublishDateTo] = new Parameter(ZakupkiParameterType.PublishDateTo, value.ToString("d"));
            }
        }
        private bool mFz44;
        public bool Fz44
        {
            get
            {
                return mFz44;
            }
            set
            {
                mFz44 = value;
                mParameters[ZakupkiParameterType.Fz44] = new Parameter(ZakupkiParameterType.Fz44, value ? "on" : null);
            }
        }
        private bool mFz223;
        public bool Fz223
        {
            get
            {
                return mFz223;
            }
            set
            {
                mFz223 = value;
                mParameters[ZakupkiParameterType.Fz223] = new Parameter(ZakupkiParameterType.Fz223, value ? "on" : null);
            }
        }
        private bool mFz94;
        public bool Fz94
        {
            get
            {
                return mFz94;
            }
            set
            {
                mFz94 = value;
                mParameters[ZakupkiParameterType.Fz94] = new Parameter(ZakupkiParameterType.Fz94, value ? "on" : null);
            }
        }

        public IEnumerable<IParameterType> Keys
        {
            get
            {
                return mParameters.Keys;
            }
        }

        public IEnumerable<Parameter> Values
        {
            get
            {
                return mParameters.Values;
            }
        }

        public int Count
        {
            get
            {
                return mParameters.Count;
            }
        }

        public Parameter this[IParameterType key]
        {
            get
            {
                return mParameters[key];
            }
            private set
            {
                if (value != null)
                    mParameters[key] = value;
                else
                    mParameters.Remove(key);
            }
        }

        public ZakupkiParameters()
        {
            PageNumber = 1;
            RecordsPerPage = MaxRecordsPerPage;
            CostFrom = 0;
            CostTo = 200000000000;
            PublishDateFrom = DateTime.Now;
            PublishDateTo = DateTime.Now;
            Fz44 = true;
            Fz223 = false;
            Fz94 = false;
        }

        public override string ToString()
        {
            return string.Join(string.Empty, mParameters.Select(parameter => parameter.Value.ToString()));
        }

        public bool ContainsKey(IParameterType key)
        {
            return mParameters.ContainsKey(key);
        }

        public bool TryGetValue(IParameterType key, out Parameter value)
        {
            return mParameters.TryGetValue(key, out value);
        }

        public IEnumerator<KeyValuePair<IParameterType, Parameter>> GetEnumerator()
        {
            return mParameters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return mParameters.GetEnumerator();
        }

        public object Clone() => MemberwiseClone();
    }
}
