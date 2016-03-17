using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ParseZakupki.Parameter.Common;

namespace ParseZakupki.Parameter.ZakupkiParameter
{
    public class ZakupkiParameter : IReadOnlyDictionary<IParameterType, Common.Parameter>, IPageParameter
    {
        public const int MaxRecordsPerPage = 500;

        private readonly Dictionary<IParameterType, Common.Parameter> _parameter = new Dictionary<IParameterType, Common.Parameter>();

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
                _parameter[ZakupkiParameterType.PageNumber] = new Common.Parameter(ZakupkiParameterType.PageNumber, value.ToString());
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
                _parameter[ZakupkiParameterType.RecordsPerPage] = new Common.Parameter(ZakupkiParameterType.RecordsPerPage, '_' + value.ToString());
            }
        }
        private double _costFrom;
        public double CostFrom
        {
            get
            {
                return _costFrom;
            }
            set
            {
                _costFrom = value;
                _parameter[ZakupkiParameterType.PriceFrom] = new Common.Parameter(ZakupkiParameterType.PriceFrom, value.ToString());
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
                _costTo = value;
                _parameter[ZakupkiParameterType.PriceTo] = new Common.Parameter(ZakupkiParameterType.PriceTo, value.ToString());
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
                _parameter[ZakupkiParameterType.PublishDateFrom] = new Common.Parameter(ZakupkiParameterType.PublishDateFrom, value.ToString("d"));
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
                _parameter[ZakupkiParameterType.PublishDateTo] = new Common.Parameter(ZakupkiParameterType.PublishDateTo, value.ToString("d"));
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
                _parameter[ZakupkiParameterType.Fz44] = new Common.Parameter(ZakupkiParameterType.Fz44, value ? "on" : null);
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
                _parameter[ZakupkiParameterType.Fz223] = new Common.Parameter(ZakupkiParameterType.Fz223, value ? "on" : null);
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
                _parameter[ZakupkiParameterType.Fz94] = new Common.Parameter(ZakupkiParameterType.Fz94, value ? "on" : null);
            }
        }

        public IEnumerable<IParameterType> Keys => _parameter.Keys;

        public IEnumerable<Common.Parameter> Values => _parameter.Values;

        public int Count => _parameter.Count;

        public Common.Parameter this[IParameterType key]
        {
            get
            {
                return _parameter[key];
            }
            private set
            {
                if (value != null)
                    _parameter[key] = value;
                else
                    _parameter.Remove(key);
            }
        }

        public ZakupkiParameter()
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

        public override string ToString() => string.Join(string.Empty, _parameter.Select(parameter => parameter.Value.ToString()));

        public bool ContainsKey(IParameterType key) => _parameter.ContainsKey(key);

        public bool TryGetValue(IParameterType key, out Common.Parameter value) => _parameter.TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<IParameterType, Common.Parameter>> GetEnumerator() => _parameter.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _parameter.GetEnumerator();

        public object Clone() => MemberwiseClone();
    }
}
