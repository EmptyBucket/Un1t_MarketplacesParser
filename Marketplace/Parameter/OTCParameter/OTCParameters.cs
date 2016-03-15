using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ParseZakupki.Parameter.Common;

namespace ParseZakupki.Parameter.OTCParameter
{
    public class OtcParameters : IReadOnlyDictionary<IParameterType, Common.Parameter>, IPageParameters
    {
        public const int MaxRecordsPerPage = 100;

        private readonly Dictionary<IParameterType, Common.Parameter> _parameters = new Dictionary<IParameterType, Common.Parameter>();

        public Common.Parameter this[IParameterType key] => _parameters[key];

        private long _costFrom;
        public long CostFrom
        {
            get
            {
                return _costFrom;
            }
            set
            {
                _parameters[OtcParametersType.MinPrice] = new Common.Parameter(OtcParametersType.MinPrice, value.ToString());
                _costFrom = value;
            }
        }

        private long _costTo;
        public long CostTo
        {
            get
            {
                return _costTo;
            }
            set
            {
                _parameters[OtcParametersType.MaxPrice] = new Common.Parameter(OtcParametersType.MaxPrice, value.ToString());
                _costTo = value;
            }
        }

        public int Count => _parameters.Count;

        public IEnumerable<IParameterType> Keys => _parameters.Keys;

        private int _pageNumber;
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _parameters[OtcParametersType.PageIndex] = new Common.Parameter(OtcParametersType.PageIndex, value.ToString());
                _pageNumber = value;
            }
        }

        private DateTime _publishDateFrom;
        public DateTime PublishDateFrom
        {
            get
            {
                return _publishDateFrom;
            }
            set
            {
                _parameters[OtcParametersType.DatePublishedFrom] = new Common.Parameter(OtcParametersType.DatePublishedFrom, value.ToString("d"));
                _publishDateFrom = value;
            }
        }

        private DateTime _publishDateTo;
        public DateTime PublishDateTo
        {
            get
            {
                return _publishDateTo;
            }
            set
            {
                _parameters[OtcParametersType.DatePublishedTo] = new Common.Parameter(OtcParametersType.DatePublishedTo, value.ToString("d"));
                _publishDateTo = value;
            }
        }

        private int _recordsPage;
        public int RecordsPerPage
        {
            get
            {
                return _recordsPage;
            }
            set
            {
                _parameters[OtcParametersType.PageSize] = new Common.Parameter(OtcParametersType.PageSize, value.ToString());
                _recordsPage = value;
            }
        }

        public IEnumerable<Common.Parameter> Values => _parameters.Values;

        private bool _fz44;
        public bool Fz44
        {
            get
            {
                return _fz44; 
            }
            set
            {
                _parameters[OtcParametersType.OrganizationLevels] = new Common.Parameter(OtcParametersType.OrganizationLevels, value ? "Fz44" : null);
                _fz44 = value;
            }
        }
        private bool _fz223;
        public bool Fz223
        {
            get
            {
                return _fz223;
            }
            set
            {
                _parameters[OtcParametersType.OrganizationLevels] = new Common.Parameter(OtcParametersType.OrganizationLevels, value ? "Fz223" : null);
                _fz223 = value;
            }
        }
        private bool _commercial;
        public bool Commercial
        {
            get
            {
                return _commercial;
            }
            set
            {
                _parameters[OtcParametersType.OrganizationLevels] = new Common.Parameter(OtcParametersType.OrganizationLevels, value ? "Commercial" : null);
                _commercial = value;
            }
        }

        public OtcParameters()
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

        public bool ContainsKey(IParameterType key) => _parameters.ContainsKey(key);

        public IEnumerator<KeyValuePair<IParameterType, Common.Parameter>> GetEnumerator() => _parameters.GetEnumerator();

        public bool TryGetValue(IParameterType key, out Common.Parameter value) => _parameters.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => _parameters.GetEnumerator();

        public override string ToString() => string.Join(string.Empty, _parameters.Select(parameter => parameter.Value.ToString()));
    }
}
