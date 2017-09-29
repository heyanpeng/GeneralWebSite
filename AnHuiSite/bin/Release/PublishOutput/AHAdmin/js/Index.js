
function drawPieChart(placeholder, data, position) {
    $.plot(placeholder, data, {
        series: {
            pie: {
                show: true,
                tilt: 0.8,
                highlight: {
                    opacity: 0.25
                },
                stroke: {
                    color: '#fff',
                    width: 2
                },
                startAngle: 2,
                label:
                    {
                        show: true,
                        radius: 1,
                    }
            }
        },
        legend: {
            show: true,
            position: position || "ne",
            labelBoxBorderColor: null,
            margin: [-30, 15]
        }
      ,
        //grid: {
        //    hoverable: true,
        //    clickable: true
        //}
    })
}

function drawLineChart() {
    var d1 = [];
    for (var i = 0; i < 10; i ++) {
        d1.push([i, Math.sin(i)]);
        d1.push([i,i*10]);
    }



    var sales_charts = $('#sales-charts').css({ 'width': '100%', 'height': '220px' });
    $.plot("#sales-charts", [
        { label: "Domains", data: d1 }
    ], {
        hoverable: true,
        shadowSize: 0,
        series: {
            lines: {
                show: true, label:
            {
                show: true,
            }
            },
            points: { show: true }
        },
        xaxis: {
            tickLength: 0
        },
        yaxis: {
            ticks: 10,
            min: -2,
            max: 2,
            tickDecimals: 3
        },
        grid: {
            backgroundColor: { colors: ["#fff", "#fff"] },
            borderWidth: 1,
            borderColor: '#555'
        }
    });
}
