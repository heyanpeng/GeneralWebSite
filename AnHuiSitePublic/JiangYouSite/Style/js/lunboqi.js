jQuery.noConflict();

var AcerUi = {};

AcerUi.debugMode = false;
AcerUi.$midLandFixer = null;
AcerUi.midLandFixerSelector = "#midLandFixer";

AcerUi.SMARTPHONE = "SMARTPHONE";
AcerUi.TABLET = "TABLET";
AcerUi.PC = "PC";

AcerUi._layouts = [
    { Id: AcerUi.SMARTPHONE, MaxWidth: 750 },
    { Id: AcerUi.TABLET, MaxWidth: 985 },
    { Id: AcerUi.PC, MaxWidth: 1024 }
];

AcerUi._initListeners = [];
AcerUi.addInitListener = function (eventCallBack)
{
    AcerUi._initListeners.push(eventCallBack);
};

AcerUi.init = function ()
{
    AcerUi.$midLandFixer = jQuery(AcerUi.midLandFixerSelector);

    AcerUi.addInitListener(new AcerUi.Showcase().init);

    if (AcerUi.WhereToBuy) { AcerUi.addInitListener(new AcerUi.WhereToBuy().init); }
    if (AcerUi.WhereToBuyNew) { AcerUi.addInitListener(new AcerUi.WhereToBuyNew().init); }
    if (AcerUi.RightNow) { AcerUi.addInitListener(new AcerUi.RightNow().init); }
    if (AcerUi.Gdp) { AcerUi.addInitListener(new AcerUi.Gdp().init); }
    if (AcerUi.CompareTable) { AcerUi.addInitListener(new AcerUi.CompareTable().init); }


    AcerUi._currentLayout = AcerUi.getCurrentLayout();

    AcerUi.resize();
    window.onresize = AcerUi.resize;

    for (var i = 0; i < AcerUi._initListeners.length; i++)
    {
        AcerUi._initListeners[i](AcerUi._currentLayout);
    }

};

AcerUi._resizeListeners = [];
AcerUi.addResizeListener = function (eventCallBack)
{
    AcerUi._resizeListeners.push(eventCallBack);
};

AcerUi.resize = function ()
{
    var w = parseInt(jQuery(window).width(), 10);
    var h = parseInt(jQuery(window).height(), 10);

    for (var i = 0; i < AcerUi._resizeListeners.length; i++)
    {
        AcerUi._resizeListeners[i](w, h);
    }

    var layout = AcerUi.getCurrentLayout();
    if (layout.Id != AcerUi._currentLayout.Id)
    {

        var prevLayout = AcerUi._currentLayout;
        AcerUi._currentLayout = layout;
        AcerUi.changeLayout(layout, prevLayout);
    }
};

AcerUi._changeLayoutListeners = [];
AcerUi.addChangeLayoutListener = function (eventCallBack)
{
    AcerUi._changeLayoutListeners.push(eventCallBack);
};

AcerUi.changeLayout = function (currentLayout, prevLayout)
{
    for (var i = 0; i < AcerUi._changeLayoutListeners.length; i++)
    {
        AcerUi._changeLayoutListeners[i](currentLayout, prevLayout);
    }
};
AcerUi._currentLayout = null;
AcerUi.getCurrentLayout = function ()
{
    var refWidth = parseInt(AcerUi.$midLandFixer.width(), 10);
    var layout = null;
    for (var i = 0; i < AcerUi._layouts.length; i++)
    {
        if (refWidth <= AcerUi._layouts[i].MaxWidth)
        {
            return AcerUi._layouts[i];
            break;
        }
    }
    return AcerUi._layouts[AcerUi._layouts.length - 1];
};
/*Showcase*/
AcerUi.Showcase = function ()
{
    var that = this;
    var _timer = null;
    var _timerTimeout = 5000;
    var _currentLayout = null;
    var _$showcase = null;
    var _showcaseHtml = null;
    var _$timerLines = null;

    var _imageClassName = null;

    this.init = function (layout)
    {
        _currentLayout = layout;
        _imageClassName = layout.Id.toLowerCase();

        _$showcase = jQuery("#showcase");
        _showcaseHtml = _$showcase.html();
        _$timerLines = jQuery(_$showcase.find(".timerLine"));


        //jQuery("#showcase > .content a").click(_changeSlider);//如果要点击事件换成click hyp
        jQuery("#showcase > .content a").hover(_changeSlider);
        jQuery("#showcase > .lbcontainer > .slide > .content-main-feature a").hover(_selectSliderContent);

        AcerUi.addChangeLayoutListener(that.layoutChange);
        _resetLayout(layout);
    };

    function _resetLayout(layout)
    {
        _stopAnimation();
        _currentLayout = layout;
        _imageClassName = layout.Id.toLowerCase();

        jQuery("#showcase .content-main-visual").each(function ()
        {
            jQuery(this).find("a").hide();
            jQuery(this).find("a." + _imageClassName + ":first").show();

        });
        jQuery("#showcase .lbcontainer > .slide").hide();
        jQuery("#showcase .lbcontainer > .slide:first").show();
        jQuery("#showcase .lbcontainer > .slide .feature > a").removeClass("current");
        jQuery(jQuery("#showcase .lbcontainer > .slide:first .feature > a").get(0)).addClass("current");

        _startAnimation();
        _startCounter(jQuery(jQuery("#showcase .slide").get(0)), 0);

        jQuery("#showcase .content > div").hide();
        if (AcerUi.getCurrentLayout().Id != AcerUi.SMARTPHONE)
        {
            jQuery(jQuery("#showcase .content > div").get(1)).css({ "top": 0, "left": 0, "bottom": "auto", "right": "auto" }).show();
            jQuery(jQuery("#showcase .content > div").get(2)).css({ "top": "auto", "left": 0, "bottom": 0, "right": "auto" }).show();
        }
        else
        {
            jQuery(jQuery("#showcase .content > div").get(1)).css({ "top": 0, "left": 0, "bottom": "auto", "right": "auto" }).show();
            jQuery(jQuery("#showcase .content > div").get(2)).css({ "top": 0, "left": "auto", "bottom": "auto", "right": 0 }).show();
        }

        _centerLabel();
    };

    function _centerLabel()
    {
        jQuery("#showcase > .content a span").css({ "padding-left": "0px" });
        var $slideChangers = jQuery("#showcase > .content a");
        for (var i = 0; i < $slideChangers.length; i++)
        {
            var $slideChanger = jQuery($slideChangers[i]);
            var $text = jQuery($slideChanger.find("span"));
            var pl = ($slideChanger.outerWidth() - $text.outerWidth()) / 2;
            $text.css({ "padding-left": pl + "px" });
        }
    };

    function _selectSliderContent()
    {
        _stopAnimation();
        _stopCounters();
        var imgClassName = AcerUi.getCurrentLayout().Id.toLowerCase();

        var $this = jQuery(this);
        var $links = jQuery(jQuery($this.parents(".content-main-feature")[0]).find(".feature a"));
        var ndx = $links.index($this);

        $links.removeClass("current");
        $this.addClass("current");

        var $mainContainer = jQuery($this.parents(".slide")[0]);
        if (jQuery($mainContainer.find(".content-main-visual a." + _imageClassName)[ndx]).is(":visible"))
        {
            _startCounter($mainContainer, ndx);
            _startAnimation();
            return false;
        }

        jQuery($mainContainer.find(".content-main-visual a." + _imageClassName + ":visible")).fadeOut("fast");
        jQuery(jQuery($mainContainer.find(".content-main-visual a." + _imageClassName)).get(ndx)).fadeIn("slow", function ()
        {
            _startCounter($mainContainer, ndx);
            _startAnimation();
        });
        return false;
    };

    function _changeSlider()
    {
        _stopAnimation();
        _stopCounters();

        jQuery("#showcase > .content a").unbind('click', _changeSlider);

        var $this = jQuery(this);
        var ndx = jQuery(jQuery($this.parents(".content")[0]).find("a")).index($this);

        var $sliders = jQuery("#showcase .slide");
        var $hider = jQuery(jQuery(jQuery($this.parents(".content")[0]).find("div:hidden")));
        var $shower = jQuery(jQuery("#showcase .slide").get(ndx));

        jQuery("#showcase .slide:visible").css("z-index", 0);
        jQuery(jQuery("#showcase .slide").get(ndx)).css("z-index", 1);

        jQuery($sliders.find(".feature > a")).removeClass("current");
        jQuery($shower.find(".feature > a").get(0)).addClass("current");

        jQuery("#showcase .slide:visible").fadeOut(250, function () { });
        $shower.fadeIn(750, function ()
        {
            _startCounter(jQuery(jQuery("#showcase .slide").get(ndx)), 0);
            _startAnimation();
        });

        var top = jQuery($this.parent()).position().top;
        var left = jQuery($this.parent()).position().left;
        var width = jQuery($this.parent()).outerWidth();
        var height = jQuery($this.parent()).outerHeight();

        if (_currentLayout.Id != AcerUi.SMARTPHONE)
        {
            jQuery("#showcase .slide:visible").css("z-index", "0");
            $hider.css("top", top).css("left", left - width).css("z-index", "1");
            jQuery($this.parent()).animate({ left: 0 - width - 10 }, 500, function ()
            {
                jQuery(this).hide();
            });
            jQuery($hider).show().animate({ left: 0 }, 500, function ()
            {
                jQuery("#showcase > .content a").bind('click', _changeSlider);
            });
        }
        else
        {
            jQuery("#showcase .slide:visible").css("z-index", "0");
            $hider.css("top", top - height - 10).css("left", left).css("z-index", "1");
            jQuery($this.parent()).animate({ top: 0 - height - 10 }, 500, function ()
            {
                jQuery(this).hide();
            });
            jQuery($hider).show().animate({ top: 0 }, 500, function ()
            {
                jQuery("#showcase > .content a").bind('click', _changeSlider);
            });
        }
        _resetSlider();
        return false;
    };

    function _stopCounters()
    {
        _$timerLines.hide().width(0).stop();
    };

    function _startCounter($slide, ndx)
    {
        _stopCounters();
        var endWidth = jQuery($slide.find(".feature > a").get(0)).outerWidth();
        jQuery($slide.find(".feature > a >.timerLine").get(ndx)).show().animate({ width: endWidth }, _timerTimeout + 500);
    };

    function _resetSlider()
    {
        jQuery("#showcase .lbcontainer > .slide:hidden").each(function ()
        {
            jQuery(this).find(".content-main-visual a").hide();
            jQuery(this).find(".content-main-visual a." + _imageClassName + ":first").show();
            jQuery(this).find(".timerLine").hide();
        });

        _centerLabel();
    };

    function _startAnimation()
    {
        _stopAnimation();
        _timer = window.setTimeout(_nextStep, _timerTimeout);
    };

    function _stopAnimation()
    {
        window.clearTimeout(_timer);
        _timer = null;
    };

    function _nextStep()
    {
        var featuresCount = jQuery("#showcase .slide:visible .feature").length;
        var $currentSlider = jQuery("#showcase .slide:visible");
        var $currentFeature = jQuery($currentSlider.find(".content-main-visual a." + _imageClassName + ":visible"));

        var currentSliderNdx = jQuery("#showcase .slide").index($currentSlider);
        var currentFeatureNdx = jQuery($currentSlider.find(".content-main-visual a." + _imageClassName)).index($currentFeature);

        var nextFeatureNdx = currentFeatureNdx + 1;
        var nextSliderNdx = currentSliderNdx + 1;
        if (nextFeatureNdx > featuresCount - 1)
        {
            var $sliders = jQuery("#showcase .slide");
            //if there is only one slide i loop it!
            if ($sliders.length == 1)
            {
                jQuery(jQuery($currentSlider.find(".content-main-feature .feature a")).get(0)).click();
            }
            else
            {
                nextSliderNdx = nextSliderNdx > featuresCount - 1 ? 0 : nextSliderNdx;
                jQuery(jQuery("#showcase .content a").get(nextSliderNdx)).click();
            }
        }
        else
        {
            jQuery(jQuery($currentSlider.find(".content-main-feature .feature a")).get(nextFeatureNdx)).click();
        }
        return false;
    };

    this.resize = function ()
    {
        return;
    };

    this.layoutChange = function (currentLayout, previousLayout)
    {
        if (_currentLayout == null || _currentLayout.Id == currentLayout.Id)
            return;

        _currentLayout = currentLayout;
        _imageClassName = currentLayout.Id.toLowerCase();

        _resetLayout(currentLayout);
        return;
    };
};

