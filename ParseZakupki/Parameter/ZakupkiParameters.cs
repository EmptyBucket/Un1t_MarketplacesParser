using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ParseZakupki.Parameter
{
    public class ZakupkiParameters : IReadOnlyDictionary<ZakupkiParameterType, ZakupkiParameter>
    {
        public const int MaxRecordsPerPage = 500;

        private Dictionary<ZakupkiParameterType, ZakupkiParameter> mParameters = new Dictionary<ZakupkiParameterType, ZakupkiParameter>();

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
                mParameters[ZakupkiParameterType.PageNumber] = new ZakupkiParameter(ZakupkiParameterType.PageNumber, value.ToString());
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
                mParameters[ZakupkiParameterType.RecordsPerPage] = new ZakupkiParameter(ZakupkiParameterType.RecordsPerPage, '_' + value.ToString());
            }
        }
        private long mPriceFrom;
        public long PriceFrom
        {
            get
            {
                return mPriceFrom;
            }
            set
            {
                mPriceFrom = value;
                mParameters[ZakupkiParameterType.PriceFrom] = new ZakupkiParameter(ZakupkiParameterType.PriceFrom, value.ToString());
            }
        }
        private long mPriceTo;
        public long PriceTo
        {
            get
            {
                return mPriceTo;
            }
            set
            {
                mPriceTo = value;
                mParameters[ZakupkiParameterType.PriceTo] = new ZakupkiParameter(ZakupkiParameterType.PriceTo, value.ToString());
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
                mParameters[ZakupkiParameterType.PublishDateFrom] = new ZakupkiParameter(ZakupkiParameterType.PublishDateFrom, value.ToString("d"));
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
                mParameters[ZakupkiParameterType.PublishDateTo] = new ZakupkiParameter(ZakupkiParameterType.PublishDateTo, value.ToString("d"));
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
                mParameters[ZakupkiParameterType.Fz44] = new ZakupkiParameter(ZakupkiParameterType.Fz44, value ? "on" : null);
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
                mParameters[ZakupkiParameterType.Fz223] = new ZakupkiParameter(ZakupkiParameterType.Fz223, value ? "on" : null);
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
                mParameters[ZakupkiParameterType.Fz94] = new ZakupkiParameter(ZakupkiParameterType.Fz94, value ? "on" : null);
            }
        }

        public IEnumerable<ZakupkiParameterType> Keys
        {
            get
            {
                return ((IReadOnlyDictionary<ZakupkiParameterType, ZakupkiParameter>)mParameters).Keys;
            }
        }

        public IEnumerable<ZakupkiParameter> Values
        {
            get
            {
                return ((IReadOnlyDictionary<ZakupkiParameterType, ZakupkiParameter>)mParameters).Values;
            }
        }

        public int Count
        {
            get
            {
                return ((IReadOnlyDictionary<ZakupkiParameterType, ZakupkiParameter>)mParameters).Count;
            }
        }

        public ZakupkiParameter this[ZakupkiParameterType key]
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
            PriceFrom = 0;
            PriceTo = 200000000000;
            PublishDateFrom = DateTime.Now;
            PublishDateTo = DateTime.Now;
            Fz44 = true;
            Fz94 = false;
            Fz223 = false;
        }

        public bool ContainsKey(ZakupkiParameterType key)
        {
            return ((IReadOnlyDictionary<ZakupkiParameterType, ZakupkiParameter>)mParameters).ContainsKey(key);
        }

        public bool TryGetValue(ZakupkiParameterType key, out ZakupkiParameter value)
        {
            return ((IReadOnlyDictionary<ZakupkiParameterType, ZakupkiParameter>)mParameters).TryGetValue(key, out value);
        }

        public IEnumerator<KeyValuePair<ZakupkiParameterType, ZakupkiParameter>> GetEnumerator()
        {
            return ((IReadOnlyDictionary<ZakupkiParameterType, ZakupkiParameter>)mParameters).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IReadOnlyDictionary<ZakupkiParameterType, ZakupkiParameter>)mParameters).GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(string.Empty, mParameters.Select(parameter => parameter.Value.ToString()));
        }
    }
}
