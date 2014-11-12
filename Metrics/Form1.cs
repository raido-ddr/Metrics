using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metrics
{
    public partial class Form1 : Form
    {
        private AnalyzableSource sourceCode;

        public Form1()
        {
            InitializeComponent();
        }

        private void EvaluateJilbBtn_Click(object sender, EventArgs e)
        {
            MetricEvaluationContext context = 
                new MetricEvaluationContext(new JilbEvaluationStrategy());
            JilbMetric jilbMetric = context.EvaluateMetric(sourceCode) as JilbMetric;

            StatementCountTxt.Text = jilbMetric.TotalStatementCount.ToString();
            ConditionalStatementCountTxt.Text = jilbMetric.ConditionalStatementCount.ToString();
            ConditionalNestingTxt.Text = jilbMetric.ConditionNestingLevel.ToString();
            JilbMetricTxt.Text = jilbMetric.Value.ToString("F3");

        }

        private void LoadSourceBtn_Click(object sender, EventArgs e)
        {
            EnableMetricEvaluation();

            if (SourceFileDlg.ShowDialog() == DialogResult.OK)
            {
                SourceFileTxt.Text = SourceFileDlg.FileName;
                sourceCode = new AnalyzableSource(SourceFileDlg.FileName);
                SourceCodeViewTxt.Text = sourceCode.RawRepresentation;
            }
        }

        private void EnableMetricEvaluation()
        {
            EvaluateJilbBtn.Enabled = true;
            EvaluateMyersBtn.Enabled = true;
        }

        private void EvaluateMyersBtn_Click(object sender, EventArgs e)
        {
            MetricEvaluationContext context =
                new MetricEvaluationContext(new MyersEvaluationStrategy());
            MyersMetric myersMetric = context.EvaluateMetric(sourceCode) as MyersMetric;

            MyersMetricTxt.Text = myersMetric.CyclomaticComplexity.ToString("F1");
        }

        
     
    }


}
