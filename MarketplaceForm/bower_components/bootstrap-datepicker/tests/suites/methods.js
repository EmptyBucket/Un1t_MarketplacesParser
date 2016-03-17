module('Methods', {
    setup: function(){
        this.input = $('<input type="text" value="31-03-2011">')
                        .appendTo('#qunit-fixture')
                        .datepicker({format: "dd-mm-yyyy"});
        this.dp = this.input.data('datepicker')
    },
    teardown: function(){
        this.dp.remove();
    }
});

test('remove', function(){
    var returnedObject = this.dp.remove();
    // ...
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('show', function(){
    var returnedObject = this.dp.show();
    // ...
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('hide', function(){
    var returnedObject = this.dp.hide();
    // ...
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('update - String', function(){
    var returnedObject = this.dp.update('13-03-2012');
    datesEqual(this.dp.dates[0], UTCDate(2012, 2, 13));
    var date = this.dp.picker.find('.datepicker-days td:contains(13)');
    ok(date.is('.active'), 'Date is selected');
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('update - Date', function(){
    var returnedObject = this.dp.update(new Date(2012, 2, 13));
    datesEqual(this.dp.dates[0], UTCDate(2012, 2, 13));
    var date = this.dp.picker.find('.datepicker-days td:contains(13)');
    ok(date.is('.active'), 'Date is selected');
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('update - null', function(){
    var returnedObject = this.dp.update(null);
    equal(this.dp.dates[0], undefined);
    var selected = this.dp.picker.find('.datepicker-days td.active');
    equal(selected.length, 0, 'No date is selected');
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('setDate', function(){
    var dateIn = new Date(2013, 1, 1),
        expectedDate = new Date(Date.UTC(2013, 1, 1)),
        returnedObject;

    notEqual(this.dp.dates[0], dateIn);
    returnedObject = this.dp.setDate(dateIn);
    strictEqual(returnedObject, this.dp, "is chainable");
    datesEqual(this.dp.dates[0], expectedDate);
});

test('setUTCDate', function(){
    var dateIn = new Date(Date.UTC(2012, 3, 5)),
        expectedDate = dateIn,
        returnedObject;

    notEqual(this.dp.dates[0], dateIn);
    returnedObject = this.dp.setUTCDate(dateIn);
    strictEqual(returnedObject, this.dp, "is chainable");
    datesEqual(this.dp.dates[0], expectedDate);
});

test('setStartDate', function(){
    var dateIn = new Date(Date.UTC(2012, 3, 5)),
        expectedDate = dateIn,
        returnedObject = this.dp.setStartDate(dateIn);
    // ...
    datesEqual(this.dp.o.startDate, expectedDate);
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('setEndDate', function(){
    var dateIn = new Date(Date.UTC(2012, 3, 5)),
        expectedDate = dateIn,
        returnedObject = this.dp.setEndDate(dateIn);
    // ...
    datesEqual(this.dp.o.endDate, expectedDate);
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('getStartDate', function(){
    var dateIn = new Date(Date.UTC(2012, 3, 5)),
        expectedDate = dateIn,
        returnedObject = this.dp.setStartDate(dateIn);
    // ...
    datesEqual(returnedObject.getStartDate(), expectedDate);
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('getEndDate', function(){
    var dateIn = new Date(Date.UTC(2012, 3, 5)),
        expectedDate = dateIn,
        returnedObject = this.dp.setEndDate(dateIn);
    // ...
    datesEqual(returnedObject.getEndDate(), expectedDate);
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('setDaysOfWeekDisabled - String', function(){
    var daysIn = "0,6",
        expectedDays = [0,6],
        returnedObject = this.dp.setDaysOfWeekDisabled(daysIn);
    // ...
    deepEqual(this.dp.o.daysOfWeekDisabled, expectedDays);
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('setDaysOfWeekDisabled - Array', function(){
    var daysIn = [0,6],
        expectedDays = daysIn,
        returnedObject = this.dp.setDaysOfWeekDisabled(daysIn);
    // ...
    deepEqual(this.dp.o.daysOfWeekDisabled, expectedDays);
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('setValue', function(){
    var returnedObject = this.dp.setValue();
    // ...
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('place', function(){
    var returnedObject = this.dp.place();
    // ...
    strictEqual(returnedObject, this.dp, "is chainable");
});

test('moveMonth - can handle invalid date', function(){
    // any input which results in an invalid date, f.e. an incorrectly formatted.
    var invalidDate = new Date("invalid"),
        returnedObject = this.dp.moveMonth(invalidDate, 1);
    // ...
    equal(this.input.val(), "31-03-2011", "date is reset");
});

test('parseDate - outputs correct value', function(){
    var parsedDate = $.fn.datepicker.DPGlobal.parseDate('11/13/2015',$.fn.datepicker.DPGlobal.parseFormat('mm/dd/yyyy'),'en');
    equal(parsedDate.getDate(), "13", "date is correct");
    equal(parsedDate.getMonth(), "10", "month is correct");
    equal(parsedDate.getFullYear(), "2015", "fullyear is correct");
});

test('parseDate - outputs correct value for yyyy\u5E74mm\u6708dd\u65E5 format', function(){
    var parsedDate = $.fn.datepicker.DPGlobal.parseDate('2015\u5E7411\u670813',$.fn.datepicker.DPGlobal.parseFormat('yyyy\u5E74mm\u6708dd\u65E5'),'ja');
    equal(parsedDate.getDate(), "13", "date is correct");
    equal(parsedDate.getMonth(), "10", "month is correct");
    equal(parsedDate.getFullYear(), "2015", "fullyear is correct");
});

test('parseDate - outputs correct value for dates containing unicodes', function(){
    var parsedDate = $.fn.datepicker.DPGlobal.parseDate('\u5341\u4E00\u6708 13 2015',$.fn.datepicker.DPGlobal.parseFormat('MM dd yyyy'),'zh-CN');
    equal(parsedDate.getDate(), "13", "date is correct");
    equal(parsedDate.getMonth(), "10", "month is correct");
    equal(parsedDate.getFullYear(), "2015", "fullyear is correct");
});
