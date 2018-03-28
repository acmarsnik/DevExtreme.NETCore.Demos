using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtreme.NETCore.Demos.Models;
using DevExtreme.NETCore.Demos.Models.SampleData;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DevExtreme.NETCore.Demos.Controllers {
    public class ChartsController : Controller {
        public ActionResult SimpleArray() {
            return View();
        }

        public ActionResult AjaxRequest() {
            return View();
        }

        #region ClientSideDataProcessing
        public ActionResult ClientSideDataProcessing() {
            return View();
        }

        public ContentResult GetMonthWeatherData() {
            return Content(JsonConvert.SerializeObject(SampleData.MonthWeather), "application/json"); ;
        }
        #endregion

        public ActionResult ServerSideDataProcessing() {
            return View(SampleData.MonthNames);
        }

        public ActionResult StandardBar() {
            return View();
        }

        public ActionResult SideBySideBar() {
            return View();
        }

        public ActionResult StackedBar() {
            return View();
        }

        public ActionResult FullStackedBar() {
            return View();
        }

        public ActionResult SideBySideStackedBar() {
            return View();
        }

        public ActionResult SideBySideFullStackedBar() {
            return View();
        }

        public ActionResult AutoCalculatedBarWidth() {
            return View();
        }

        public ActionResult CustomBarWidth() {
            return View();
        }

        public ActionResult ColorEachBar() {
            return View();
        }

        public ActionResult Line() {
            return View();
        }

        public ActionResult Spline() {
            return View();
        }

        public ActionResult ScaleBreaks()
        {
            return View();
        }

        public ActionResult Scatter() {
            return View(SampleData.GetScatterData());
        }

        public ActionResult StepLine() {
            return View(SampleData.AustralianOlympicMedals);
        }

        public ActionResult Bubble() {
            return View();
        }

        public ActionResult Stock() {
            return View(SampleData.FinancialData);
        }

        public ActionResult Candlestick() {
            return View(SampleData.FinancialData);
        }

        public ActionResult FunnelChart() {
            return View();
        }

        public ActionResult Area() {
            return View();
        }

        public ActionResult SplineArea() {
            return View();
        }

        public ActionResult StepArea() {
            return View(SampleData.AustralianOlympicMedals);
        }

        public ActionResult RangeBar() {
            return View();
        }

        public ActionResult RangeArea() {
            return View();
        }

        public ActionResult Pie() {
            return View();
        }

        public ActionResult PiesWithEqualSize() {
            return View();
        }

        public ActionResult PieWithCustomLabels() {
            return View();
        }

        public ActionResult PieWithSmallValuesGrouped() {
            return View(SampleData.LanguagesPercentage);
        }

        public ActionResult PieWithResolvedLabelOverlapping() {
            return View();
        }

        public ActionResult PieWithMultipleSeries() {
            return View();
        }

        public ActionResult Doughnut() {
            return View(SampleData.PopulationData);
        }

        public ActionResult DoughnutSelection() {
            return View();
        }

        public ActionResult DoughnutWithTopNSeries() {
            return View();
        }

        public ActionResult ZoomingAndScrolling() {
            return View(SampleData.PointsData);
        }

        public ActionResult ZoomingAndScrollingAPI() {
            return View(SampleData.PointsData);
        }

        public ActionResult AxisLabelsOverlapping() {
            return View();
        }

        public ActionResult ChartsDrillDown() {
            return View();
        }
        
        public ActionResult MultipleAxes() {
            return View();
        }

        public ActionResult MultiplePanes() {
            return View();
        }

        public ActionResult HoverMode() {
            return View();
        }

        public ActionResult Selection() {
            return View();
        }

        public ActionResult MultipleSeriesSelection() {
            return View();
        }

        public ActionResult MultiplePointSelection() {
            return View();
        }

        public ActionResult SeriesTemplates() {
            return View(SampleData.OilProductionData);
        }

        public ActionResult NullPointSupport() {
            return View();
        }

        public ActionResult APISelectAPoint() {
            return View();
        }

        public ActionResult APIDisplayATooltip() {
            return View(SampleData.PopulationData);
        }

        public ActionResult TooltipHTMLSupport() {
            return View();
        }

        public ActionResult Crosshair() {
            return View();
        }

        public ActionResult PointImage() {
            return View();
        }

        public ActionResult CustomizePointsAndLabels() {
            return View();
        }

        public ActionResult LogarithmicAxis() {
            return View();
        }

        #region PointsAggregation
        public ActionResult PointsAggregation() {
            return View();
        }

        [HttpGet]
        public ActionResult GetPoints(DataSourceLoadOptions loadOptions) {
            var data = new List<object>();
            var rnd = new Random();
            var max = 5000;

            for(var i = 0; i < max; i++) {
                data.Add(new { Arg = i, Val = i + i * (rnd.NextDouble() - 0.5) });
            }

            return Content(JsonConvert.SerializeObject(data), "application/json");
        }
        #endregion

        #region PointsAggregationFinancialChart
        public ActionResult PointsAggregationFinancialChart() {
            return View();
        }

        [HttpGet]
        public ActionResult GetStockPrices(DataSourceLoadOptions loadOptions) {
            return Content(JsonConvert.SerializeObject(SampleData.StockPrices), "application/json");
        }
        #endregion

        public ActionResult DiscreteAxisZoomingAndScrolling() {
            return View();
        }

        public ActionResult ErrorBars() {
            return View();
        }

        public ActionResult ExportAndPrintingAPI() {
            return View();
        }

        public ActionResult ExportSeveralCharts() {
            return View();
        }

        #region ParetoChart
        public ActionResult ParetoChart() {
            return View();
        }
        public ActionResult Overview() {
            return View();
        }

        [HttpGet]
        public ActionResult GetComplaintsData(DataSourceLoadOptions loadOptions)
        {
            var data = SampleData.ParetoChartData;
            var totalCount = 0;
            var dataSource = new List<object>();
            var cumulativeCount = 0;

            data.Sort((ParetoChartData a, ParetoChartData b) => {
                return b.count.CompareTo(a.count);
            });

            data.ForEach((ParetoChartData item) => {
                totalCount += item.count;
            });

            data.ForEach((ParetoChartData item) => {
                cumulativeCount += item.count;
                dataSource.Add(new
                {
                    complaint = item.complaint,
                    count = item.count,
                    cumulativePercentage = Math.Round((double)cumulativeCount * 100 / totalCount)
                });
            });

            return Content(JsonConvert.SerializeObject(dataSource), "application/json");
        }
        #endregion

        public ActionResult ContinuousData() {
            return View();
        }

        public ActionResult DiscreteData() {
            return View();
        }

        public ActionResult SpiderWeb() {
            return View();
        }

        public ActionResult WindRose() {
            return View(SampleData.WindRoseData);
        }

        public ActionResult PeriodicData() {
            return View();
        }

        public ActionResult InvertedChart() {
            return View();
        }

        public ActionResult SimpleSparklines() {
            return View(SampleData.MonthlyPrices);
        }

        public ActionResult AreaSparklines() {
            return View(SampleData.MonthlyPrices);
        }

        #region BarSparklines
        public ActionResult BarSparklines() {
            return View();
        }

        [HttpGet]
        public ActionResult GetMonthlyPrices(DataSourceLoadOptions loadOptions) {
            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(SampleData.MonthlyPrices, loadOptions)), "application/json");
        }
        #endregion

        public ActionResult WinlossSparklines() {
            return View(SampleData.MonthlyPrices);
        }

        public ActionResult SimpleBullets() {
            return View();
        }

        public ActionResult HierarchicalDataStructure() {
            return View();
        }

        public ActionResult FlatDataStructure() {
            return View();
        }

        public ActionResult TilingAlgorithms() {
            return View();
        }

        public ActionResult Colorization() {
            return View();
        }

        public ActionResult DrillDown() {
            return View(SampleData.ContinentsPopulation);
        }

        public ActionResult PyramidChart() {
            return View();
        }
    }
}