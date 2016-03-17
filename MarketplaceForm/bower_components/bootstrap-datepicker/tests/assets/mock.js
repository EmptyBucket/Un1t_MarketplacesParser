;(function(){

window.patch_date = function patch(f){
    var nativeDate = window.Date;
    var date = function date(y,m,d,h,i,s,j){
        switch(arguments.length){
            case 0: return date.now ? new nativeDate(date.now) : new nativeDate();
            case 1: return new nativeDate(y);
            case 2: return new nativeDate(y,m);
            case 3: return new nativeDate(y,m,d);
            case 4: return new nativeDate(y,m,d,h);
            case 5: return new nativeDate(y,m,d,h,i);
            case 6: return new nativeDate(y,m,d,h,i,s);
            case 7: return new nativeDate(y,y,m,d,h,i,s,j);
        }
    };
    date.UTC = nativeDate.UTC;
    return function(){
        Array.prototype.push.call(arguments, date);
        window.Date = date;
        res = f.apply(this, arguments);
        window.Date = nativeDate;
    }
}


window.patch_show_hide = function patch(f){
    var oldShow = $.fn.show,
        newShow = function () {
            $(this).removeClass('foo');
            return oldShow.apply(this, arguments);
        };

    var oldHide = $.fn.hide,
        newHide = function () {
            $(this).addClass('foo');
            return oldHide.apply(this, arguments);
        };

    return function(){
        $.fn.show = newShow;
        $.fn.hide = newHide;
        f.apply(this, arguments);
        $.fn.show = oldShow;
        $.fn.hide = oldHide;
    }
}

}());