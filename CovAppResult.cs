using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovApp3DimScore
{
    struct CovAppResult
    {
        public const double MaxSevereCaseRisk = 13D;
        public double SevereCaseRisk;
        public const double MaxEpidemicRisk = 3D;
        public double EpidemicRisk;
        public const double MaxPreTestProbability = 5D;
        public double PreTestProbability;
        public bool ShowSingleWarning;
        public bool ShowGroupWarning;
        public bool ShowShortnessOfBreathWarning;

        public double SevereCaseRiskScore => SevereCaseRisk / MaxSevereCaseRisk;
        public double EpidemicRiskScore => EpidemicRisk / MaxEpidemicRisk;
        public double PreTestProbabilityScore => PreTestProbability / MaxPreTestProbability;
    }
}
