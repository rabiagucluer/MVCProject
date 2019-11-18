$(function () {

    var slider = $('.slider'),
        list = slider.find('ul.slider_liste'),
        length = list.find('li').length,
        width = slider.outerWidth(),
        totalWidth = width * length,
        height = slider.outerHeight,
        totalHeight = height * length,
        index = 0,


        next = $('a.sonraki', slider),
        prev = $('a.onceki', slider);

    list.find('li').width(width).end().width(totalWidth);
    list.find('li').height(innerHeight).end().height(totalHeight);

    /*responsive*/
    $(window).resize(function () {
        width = slider.outerWidth();
        totalWidth = width * length;
        list.find('li').width(width).end().width(totalWidth).css('margin-Left', '-' + (index * width) + 'px');
        list.find('li').height(height).end().height(totalHeight).css('margin-Down', '-' + (index * height) + 'px');
    });

    /*sonraki*/
    next.on('click', function () {
        if (index < length - 1) index++;
        else index = 0;
        list.stop().animate({
            marginLeft: '-' + (index * width)
        }, 500);
        return false
    });

    /*önceki*/
    prev.on('click', function () {
        if (index > 0) index--;
        list.stop().animate({
            marginLeft: '-' + (index * width)
        }, 500);
        return false
    });

    //alert(length);
});