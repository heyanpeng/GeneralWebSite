;(function($){
/**
 * jqGrid English Translation
 * Tony Tomov tony@trirand.com
 * http://trirand.com/blog/ 
 * Dual licensed under the MIT and GPL licenses:
 * http://www.opensource.org/licenses/mit-license.php
 * http://www.gnu.org/licenses/gpl.html
**/
$.jgrid = $.jgrid || {};
$.extend($.jgrid,{
    defaults: {
        recordtext: "{0} - {1}\u3000�� {2} ��",	// ����ǰ��ȫ�ǿո�
        emptyrecords: "��������ʾ",
        loadtext: "��ȡ��...",
        pgtext: " {0} �� {1} ҳ"
    },
    search: {
        caption: "����...",
        Find: "����",
        Reset: "����",
        odata: ['����\u3000\u3000', '����\u3000\u3000', 'С��\u3000\u3000', 'С�ڵ���', '����\u3000\u3000', '���ڵ���',
			'��ʼ��', '����ʼ��', '����\u3000\u3000', '������', '������', '��������', '����\u3000\u3000', '������'],
        groupOps: [{ op: "AND", text: "����" }, { op: "OR", text: "��һ" }],
        matchText: " ƥ��",
        rulesText: " ����"
    },
    edit: {
        addCaption: "��Ӽ�¼",
        editCaption: "�༭��¼",
        bSubmit: "�ύ",
        bCancel: "ȡ��",
        bClose: "�ر�",
        saveData: "�����Ѹı䣬�Ƿ񱣴棿",
        bYes: "��",
        bNo: "��",
        bExit: "ȡ��",
        msg: {
            required: "���ֶα���",
            number: "��������Ч����",
            minValue: "��ֵ������ڵ��� ",
            maxValue: "��ֵ����С�ڵ��� ",
            email: "�ⲻ����Ч��e-mail��ַ",
            integer: "��������Ч����",
            date: "��������Чʱ��",
            url: "��Ч��ַ��ǰ׺����Ϊ ('http://' �� 'https://')",
            nodefined: " δ���壡",
            novalue: " ��Ҫ����ֵ��",
            customarray: "�Զ��庯����Ҫ�������飡",
            customfcheck: "Custom function should be present in case of custom checking!"

        }
    },
    view: {
        caption: "�鿴��¼",
        bClose: "�ر�"
    },
    del: {
        caption: "ɾ��",
        msg: "ɾ����ѡ��¼��",
        bSubmit: "ɾ��",
        bCancel: "ȡ��"
    },
    nav: {
        edittext: "",
        edittitle: "�༭��ѡ��¼",
        addtext: "",
        addtitle: "����¼�¼",
        deltext: "",
        deltitle: "ɾ����ѡ��¼",
        searchtext: "",
        searchtitle: "����",
        refreshtext: "",
        refreshtitle: "ˢ�±��",
        alertcap: "ע��",
        alerttext: "��ѡ���¼",
        viewtext: "",
        viewtitle: "�鿴��ѡ��¼"
    },
    col: {
        caption: "ѡ����",
        bSubmit: "ȷ��",
        bCancel: "ȡ��"
    },
    errors: {
        errcap: "����",
        nourl: "û������url",
        norecords: "û��Ҫ����ļ�¼",
        model: "colNames �� colModel ���Ȳ��ȣ�"
    },
	formatter : {
		integer : {thousandsSeparator: ",", defaultValue: '0'},
		number : {decimalSeparator:".", thousandsSeparator: ",", decimalPlaces: 2, defaultValue: '0.00'},
		currency : {decimalSeparator:".", thousandsSeparator: ",", decimalPlaces: 2, prefix: "", suffix:"", defaultValue: '0.00'},
		date : {
			dayNames:   [
				"Sun", "Mon", "Tue", "Wed", "Thr", "Fri", "Sat",
				"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
			],
			monthNames: [
				"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec",
				"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
			],
			AmPm : ["am","pm","AM","PM"],
			S: function (j) {return j < 11 || j > 13 ? ['st', 'nd', 'rd', 'th'][Math.min((j - 1) % 10, 3)] : 'th';},
			srcformat: 'Y-m-d',
			newformat: 'n/j/Y',
			parseRe : /[Tt\\\/:_;.,\t\s-]/,
			masks : {
				// see http://php.net/manual/en/function.date.php for PHP format used in jqGrid
				// and see http://docs.jquery.com/UI/Datepicker/formatDate
				// and https://github.com/jquery/globalize#dates for alternative formats used frequently
				// one can find on https://github.com/jquery/globalize/tree/master/lib/cultures many
				// information about date, time, numbers and currency formats used in different countries
				// one should just convert the information in PHP format
				ISO8601Long:"Y-m-d H:i:s",
				ISO8601Short:"Y-m-d",
				// short date:
				//    n - Numeric representation of a month, without leading zeros
				//    j - Day of the month without leading zeros
				//    Y - A full numeric representation of a year, 4 digits
				// example: 3/1/2012 which means 1 March 2012
				ShortDate: "n/j/Y", // in jQuery UI Datepicker: "M/d/yyyy"
				// long date:
				//    l - A full textual representation of the day of the week
				//    F - A full textual representation of a month
				//    d - Day of the month, 2 digits with leading zeros
				//    Y - A full numeric representation of a year, 4 digits
				LongDate: "l, F d, Y", // in jQuery UI Datepicker: "dddd, MMMM dd, yyyy"
				// long date with long time:
				//    l - A full textual representation of the day of the week
				//    F - A full textual representation of a month
				//    d - Day of the month, 2 digits with leading zeros
				//    Y - A full numeric representation of a year, 4 digits
				//    g - 12-hour format of an hour without leading zeros
				//    i - Minutes with leading zeros
				//    s - Seconds, with leading zeros
				//    A - Uppercase Ante meridiem and Post meridiem (AM or PM)
				FullDateTime: "l, F d, Y g:i:s A", // in jQuery UI Datepicker: "dddd, MMMM dd, yyyy h:mm:ss tt"
				// month day:
				//    F - A full textual representation of a month
				//    d - Day of the month, 2 digits with leading zeros
				MonthDay: "F d", // in jQuery UI Datepicker: "MMMM dd"
				// short time (without seconds)
				//    g - 12-hour format of an hour without leading zeros
				//    i - Minutes with leading zeros
				//    A - Uppercase Ante meridiem and Post meridiem (AM or PM)
				ShortTime: "g:i A", // in jQuery UI Datepicker: "h:mm tt"
				// long time (with seconds)
				//    g - 12-hour format of an hour without leading zeros
				//    i - Minutes with leading zeros
				//    s - Seconds, with leading zeros
				//    A - Uppercase Ante meridiem and Post meridiem (AM or PM)
				LongTime: "g:i:s A", // in jQuery UI Datepicker: "h:mm:ss tt"
				SortableDateTime: "Y-m-d\\TH:i:s",
				UniversalSortableDateTime: "Y-m-d H:i:sO",
				// month with year
				//    Y - A full numeric representation of a year, 4 digits
				//    F - A full textual representation of a month
				YearMonth: "F, Y" // in jQuery UI Datepicker: "MMMM, yyyy"
			},
			reformatAfterEdit : false
		},
		baseLinkUrl: '',
		showAction: '',
		target: '',
		checkbox : {disabled:true},
		idName : 'id'
	}
});
})(jQuery);