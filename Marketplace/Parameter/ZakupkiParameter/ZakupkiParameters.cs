using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ParseZakupki.Parameter.Common;

namespace ParseZakupki.Parameter.ZakupkiParameter
{
    public class ZakupkiParameters : IReadOnlyDictionary<IParameterType, Common.Parameter>, IPageParameters
    {
        public const int MaxRecordsPerPage = 500;

        private readonly Dictionary<IParameterType, Common.Parameter> _parameters = new Dictionary<IParameterType, Common.Parameter>();

        private int _pageNumber;
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value;
                _parameters[ZakupkiParameterType.PageNumber] = new Common.Parameter(ZakupkiParameterType.PageNumber, value.ToString());
            }
        }
        private int _recordsPerPage;
        public int RecordsPerPage
        {
            get
            {
                return _recordsPerPage;
            }
            set
            {
                _recordsPerPage = value;
                _parameters[ZakupkiParameterType.RecordsPerPage] = new Common.Parameter(ZakupkiParameterType.RecordsPerPage, '_' + value.ToString());
            }
        }
        private long _costFrom;
        public long CostFrom
        {
            get
            {
                return _costFrom;
            }
            set
            {
                _costFrom = value;
                _parameters[ZakupkiParameterType.PriceFrom] = new Common.Parameter(ZakupkiParameterType.PriceFrom, value.ToString());
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
                _costTo = value;
                _parameters[ZakupkiParameterType.PriceTo] = new Common.Parameter(ZakupkiParameterType.PriceTo, value.ToString());
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
                _publishDateFrom = value;
                _parameters[ZakupkiParameterType.PublishDateFrom] = new Common.Parameter(ZakupkiParameterType.PublishDateFrom, value.ToString("d"));
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
                _publishDateTo = value;
                _parameters[ZakupkiParameterType.PublishDateTo] = new Common.Parameter(ZakupkiParameterType.PublishDateTo, value.ToString("d"));
            }
        }
        private bool _fz44;
        public bool Fz44
        {
            get
            {
                return _fz44;
            }
            set
            {
                _fz44 = value;
                _parameters[ZakupkiParameterType.Fz44] = new Common.Parameter(ZakupkiParameterType.Fz44, value ? "on" : null);
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
                _fz223 = value;
                _parameters[ZakupkiParameterType.Fz223] = new Common.Parameter(ZakupkiParameterType.Fz223, value ? "on" : null);
            }
        }
        private bool _fz94;
        public bool Fz94
        {
            get
            {
                return _fz94;
            }
            set
            {
                _fz94 = value;
                _parameters[ZakupkiParameterType.Fz94] = new Common.Parameter(ZakupkiParameterType.Fz94, value ? "on" : null);
            }
        }

        public IEnumerable<IParameterType> Keys => _parameters.Keys;

        public IEnumerable<Common.Parameter> Values => _parameters.Values;

        public int Count => _parameters.Count;

        public Common.Parameter this[IParameterType key]
        {
            get
            {
                return _parameters[key];
            }
            private set
            {
                if (value != null)
                    _parameters[key] = value;
                else
                    _parameters.Remove(key);
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

        public override string ToString() => string.Join(string.Empty, _parameters.Select(parameter => parameter.Value.ToString()));

        public bool ContainsKey(IParameterType key) => _parameters.ContainsKey(key);

        public bool TryGetValue(IParameterType key, out Common.Parameter value) => _parameters.TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<IParameterType, Common.Parameter>> GetEnumerator() => _parameters.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _parameters.GetEnumerator();

        public object Clone() => MemberwiseClone();
    }
}
