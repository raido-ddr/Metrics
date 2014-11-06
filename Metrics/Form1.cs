using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metrics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EvaluateJilbBtn_Click(object sender, EventArgs e)
        {
            MetricEvaluationContext context = 
                new MetricEvaluationContext(new JilbEvaluationStrategy());
            JilbMetric jilbMetric = context.EvaluateMetric(null) as JilbMetric;

        }

        private void LoadSourceBtn_Click(object sender, EventArgs e)
        {
            EnableMetricEvaluation();
        }

        private void EnableMetricEvaluation()
        {
            EvaluateJilbBtn.Enabled = true;
            EvaluateMyersBtn.Enabled = true;
        }

        
     
    }


}
