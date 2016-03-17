using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ParseZakupki.Parameter.Common;

namespace ParseZakupki.Parameter.OTCParameter
{
    public class OtcParameter : IReadOnlyDictionary<IParameterType, Common.Parameter>, IPageParameter
    {
        public const int MaxRecordsPerPage = 100;

        private readonly Dictionary<IParameterType, Common.Parameter> _parameter = new Dictionary<IParameterType, Common.Parameter>();

        public Common.Parameter this[IParameterType key] => _parameter[key];

        private double _costFrom;
        public double CostFrom
        {
            get
            {
                return _costFrom;
            }
            set
            {
                _parameter[OtcParameterType.MinPrice] = new Common.Parameter(OtcParameterType.MinPrice, value.ToString());
                _costFrom = value;
            }
        }

        private double _costTo;
        public double CostTo
        {
            get
            {
                return _costTo;
            }
            set
            {
                _parameter[OtcParameterType.MaxPrice] = new Common.Parameter(OtcParameterType.MaxPrice, value.ToString());
                _costTo = value;
            }
        }

        public int Count => _parameter.Count;

        public IEnumerable<IParameterType> Keys => _parameter.Keys;

        private int _pageNumber;
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _parameter[OtcParameterType.PageIndex] = new Common.Parameter(OtcParameterType.PageIndex, value.ToString());
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
                _parameter[OtcParameterType.DatePublishedFrom] = new Common.Parameter(OtcParameterType.DatePublishedFrom, value.ToString("d"));
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
                _parameter[OtcParameterType.DatePublishedTo] = new Common.Parameter(OtcParameterType.DatePublishedTo, value.ToString("d"));
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
                _parameter[OtcParameterType.PageSize] = new Common.Parameter(OtcParameterType.PageSize, value.ToString());
                _recordsPage = value;
            }
        }

        public IEnumerable<Common.Parameter> Values => _parameter.Values;

        private bool _fz44;
        public bool Fz44
        {
            get
            {
                return _fz44; 
            }
            set
            {
                _parameter[OtcParameterType.OrganizationLevels] = new Common.Parameter(OtcParameterType.OrganizationLevels, value ? "Fz44" : null);
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
                _parameter[OtcParameterType.OrganizationLevels] = new Common.Parameter(OtcParameterType.OrganizationLevels, value ? "Fz223" : null);
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
                _parameter[OtcParameterType.OrganizationLevels] = new Common.Parameter(OtcParameterType.OrganizationLevels, value ? "Commercial" : null);
                _commercial = value;
            }
        }

        public OtcParameter()
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

        public bool ContainsKey(IParameterType key) => _parameter.ContainsKey(key);

        public IEnumerator<KeyValuePair<IParameterType, Common.Parameter>> GetEnumerator() => _parameter.GetEnumerator();

        public bool TryGetValue(IParameterType key, out Common.Parameter value) => _parameter.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => _parameter.GetEnumerator();

        public override string ToString() => string.Join(string.Empty, _parameter.Select(parameter => parameter.Value.ToString()));
    }
}
