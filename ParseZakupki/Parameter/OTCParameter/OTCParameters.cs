using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ParseZakupki.Parameter.OTCParameter
{
    public class OTCParameters : IParameters, ICloneable, IReadOnlyDictionary<IParameterType, Parameter>
    {
        public const int MaxRecordsPerPage = 100;

        private Dictionary<IParameterType, Parameter> mParameters = new Dictionary<IParameterType, Parameter>();

        public Parameter this[IParameterType key]
        {
            get
            {
                return mParameters[key];
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
                mParameters[OTCParametersType.MinPrice] = new Parameter(OTCParametersType.MinPrice, value.ToString());
                mCostFrom = value;
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
                mParameters[OTCParametersType.MaxPrice] = new Parameter(OTCParametersType.MaxPrice, value.ToString());
                mCostTo = value;
            }
        }

        public int Count
        {
            get
            {
                return mParameters.Count;
            }
        }

        public IEnumerable<IParameterType> Keys
        {
            get
            {
                return mParameters.Keys;
            }
        }

        private int mPageNumber;
        public int PageNumber
        {
            get
            {
                return mPageNumber;
            }
            set
            {
                mParameters[OTCParametersType.PageIndex] = new Parameter(OTCParametersType.PageIndex, value.ToString());
                mPageNumber = value;
            }
        }

        public DateTime mPublishDateFrom;
        public DateTime PublishDateFrom
        {
            get
            {
                return mPublishDateFrom;
            }
            set
            {
                mParameters[OTCParametersType.DatePublishedFrom] = new Parameter(OTCParametersType.DatePublishedFrom, value.ToString("d"));
                mPublishDateFrom = value;
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
                mParameters[OTCParametersType.DatePublishedTo] = new Parameter(OTCParametersType.DatePublishedTo, value.ToString("d"));
                mPublishDateTo = value;
            }
        }

        private int mRecordsPage;
        public int RecordsPerPage
        {
            get
            {
                return mRecordsPage;
            }
            set
            {
                mParameters[OTCParametersType.PageSize] = new Parameter(OTCParametersType.PageSize, value.ToString());
                mRecordsPage = value;
            }
        }

        public IEnumerable<Parameter> Values
        {
            get
            {
                return mParameters.Values;
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
                mParameters[OTCParametersType.OrganizationLevels] = new Parameter(OTCParametersType.OrganizationLevels, value ? "Fz44" : null);
                mFz44 = value;
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
                mParameters[OTCParametersType.OrganizationLevels] = new Parameter(OTCParametersType.OrganizationLevels, value ? "Fz223" : null);
                mFz223 = value;
            }
        }
        private bool mCommercial;
        public bool Commercial
        {
            get
            {
                return mCommercial;
            }
            set
            {
                mParameters[OTCParametersType.OrganizationLevels] = new Parameter(OTCParametersType.OrganizationLevels, value ? "Commercial" : null);
                mCommercial = value;
            }
        }

        public object Clone() => MemberwiseClone();

        public OTCParameters()
        {
            PageNumber = 1;
            RecordsPerPage = MaxRecordsPerPage;
            PublishDateFrom = DateTime.Now;
            PublishDateTo = DateTime.Now;
            CostFrom = 0;
            CostTo = 200000000000;
            Fz44 = true;
            Fz223 = false;
            Commercial = false;
        }

        public bool ContainsKey(IParameterType key)
        {
            return mParameters.ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<IParameterType, Parameter>> GetEnumerator()
        {
            return mParameters.GetEnumerator();
        }

        public bool TryGetValue(IParameterType key, out Parameter value)
        {
            return mParameters.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return mParameters.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(string.Empty, mParameters.Select(parameter => parameter.Value.ToString()));
        }
    }
}
