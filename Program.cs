using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CovApp3DimScore
{
    class Program
    {
        #region JSON

        private const string QuestionJson = @"
{
    ""questions"": [
        {
            ""id"": ""qAge"",
            ""type"": ""radio"",
            ""question"": ""Wie alt sind Sie?"",
            ""answers"": [
                {
                    ""id"": ""aLt40"",
                    ""text"": ""Jünger als 40""
                },
                {
                    ""id"": ""a40to50"",
                    ""text"": ""40-50""
                },
                {
                    ""id"": ""a51to60"",
                    ""text"": ""51-60""
                },
                {
                    ""id"": ""a61to70"",
                    ""text"": ""61-70""
                },
                {
                    ""id"": ""a71to80"",
                    ""text"": ""71-80""
                },
                {
                    ""id"": ""aGt80"",
                    ""text"": ""Älter als 80""
                }
            ]
        },
        {
            ""id"": ""qLivingSituation"",
            ""type"": ""radio"",
            ""question"": ""Wie ist Ihre aktuelle Wohnsituation?"",
            ""answers"": [
                {
                    ""id"": ""aSingle"",
                    ""text"": ""Allein wohnend""
                },
                {
                    ""id"": ""aGroup"",
                    ""text"": ""Zusammen mit Familie, in einer Wohngemeinschaft oder betreuten Gemeinschaftseinrichtung""
                }
            ]
        },
        {
            ""id"": ""qCare"",
            ""type"": ""radio"",
            ""question"": ""Pflegen oder unterstützen Sie privat mindestens einmal pro Woche eine oder mehrere Personen mit altersbedingten Beschwerden, chronischen Erkrankungen oder Gebrechlichkeit?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                }
            ]
        },
        {
            ""id"": ""qProfession"",
            ""type"": ""radio"",
            ""question"": ""Sind Sie in einem der folgenden Bereiche tätig?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Im medizinischen Bereich (Pflege, Arztpraxis oder Krankenhaus)""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""In einer Gemeinschaftseinrichtung (Schule, Kita, Universität, Heim etc.)""
                },
                {
                    ""id"": ""aNone"",
                    ""text"": ""Nein, in keinem der genannten Bereiche""
                }
            ]
        },
        {
            ""id"": ""qSmoking"",
            ""type"": ""radio"",
            ""question"": ""Rauchen Sie?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                }
            ]
        },
        {
            ""id"": ""qPregnant"",
            ""type"": ""radio"",
            ""question"": ""Sind Sie schwanger?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                },
                {
                    ""id"": ""aNoIdea"",
                    ""text"": ""Ich weiß es nicht""
                }
            ]
        },
        {
            ""id"": ""qContact"",
            ""type"": ""radio"",
            ""question"": ""Hatten Sie engen Kontakt zu einem bestätigten Fall?"",
            ""comment"": ""Enger Kontakt mit einem bestätigten Fall bedeutet:\n- Kontakt von Angesicht zu Angesicht länger als 15 Minuten\n- Direkter, physischer Kontakt (Berührung, Händeschütteln, Küssen)\n- Länger als 15 Minuten direkt neben einer infizierten Person (weniger als 1,5 Meter Abstand) verbracht\n- Kontakt mit oder Austausch von Körperflüssigkeiten\n- Teilen einer Wohnung\n\n\nFalls Sie Kontakt hatten, aber adäquate Schutzmaßnahmen (Maske, Kittel) getragen haben, wählen Sie \""Nein\""."",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                }
            ]
        },
        {
            ""id"": ""qFever24h"",
            ""type"": ""radio"",
            ""question"": ""Hatten Sie in den letzten 24 Std. Fieber (über 38°C)?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                }
            ]
        },
        {
            ""id"": ""qHighestFever24h"",
            ""type"": ""radio"",
            ""depends"": { ""questionId"": ""qFever24h"", ""answerId"": ""aYes"" },
            ""question"": ""Wie hoch war die höchste Temperatur ca.?"",
            ""answers"": [
                {
                    ""id"": ""a38C"",
                    ""text"": ""38°C""
                },
                {
                    ""id"": ""a38C"",
                    ""text"": ""38°C""
                },
                {
                    ""id"": ""a38C"",
                    ""text"": ""38°C""
                },
                {
                    ""id"": ""a39C"",
                    ""text"": ""39°C""
                },
                {
                    ""id"": ""a40C"",
                    ""text"": ""40°C""
                },
                {
                    ""id"": ""a41C"",
                    ""text"": ""41°C""
                },
                {
                    ""id"": ""aGt41C"",
                    ""text"": ""Über 42°C""
                },
                {
                    ""id"": ""aNoIdea"",
                    ""text"": ""Ich weiß es nicht""
                }
            ]
        },
        {
            ""id"": ""qFever4d"",
            ""type"": ""radio"",
            ""depends"": { ""questionId"": ""qFever24h"", ""answerId"": ""aNo"" },
            ""question"": ""Hatten Sie in den letzten 4 Tagen Fieber (über 38°C) ?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                }
            ]
        },
        {
            ""id"": ""qHighestFever4d"",
            ""type"": ""radio"",
            ""depends"": { ""questionId"": ""qFever4d"", ""answerId"": ""aYes"" },
            ""question"": ""Wie hoch war die höchste Temperatur ca.?"",
            ""answers"": [
                {
                    ""id"": ""a38C"",
                    ""text"": ""38°C""
                },
                {
                    ""id"": ""a38C"",
                    ""text"": ""38°C""
                },
                {
                    ""id"": ""a38C"",
                    ""text"": ""38°C""
                },
                {
                    ""id"": ""a39C"",
                    ""text"": ""39°C""
                },
                {
                    ""id"": ""a40C"",
                    ""text"": ""40°C""
                },
                {
                    ""id"": ""a41C"",
                    ""text"": ""41°C""
                },
                {
                    ""id"": ""aGt41C"",
                    ""text"": ""Über 42°C""
                },
                {
                    ""id"": ""aNoIdea"",
                    ""text"": ""Ich weiß es nicht""
                }
            ]
        },
        {
            ""id"": ""qSymptoms24h1"",
            ""type"": ""check"",
            ""question"": ""Welche der folgenden Symptome hatten Sie in den letzten 24 Std.? (Mehrfachauswahl möglich)"",
            ""comment"": ""Die Frage bezieht sich auf akut aufgetretene oder verstärkte Symptome und schließt chronische Beschwerden und saisonale bzw. allergische Beschwerden aus. Sollten Sie eine chronische Erkrankung haben, vergleichen Sie für die Beantwortung der Frage Ihre derzeitigen mit Ihren bisherigen Beschwerden."",
            ""answers"": [
                {
                    ""id"": ""aShivering"",
                    ""text"": ""Schüttelfrost""
                },
                {
                    ""id"": ""aAchingLimbs"",
                    ""text"": ""Gliederschmerzen""
                },
                {
                    ""id"": ""aLossOfTasteOrSmell"",
                    ""text"": ""Geschmacks- oder Geruchsverlust""
                }
            ]
        },
        {
            ""id"": ""qSymptoms24h2"",
            ""type"": ""check"",
            ""question"": ""Welche der folgenden Symptome hatten Sie in den letzten 24 Std.? (Mehrfachauswahl möglich)"",
            ""answers"": [
                {
                    ""id"": ""aFatigue"",
                    ""text"": ""Fühlte mich schlapp oder abgeschlagen""
                },
                {
                    ""id"": ""aCough"",
                    ""text"": ""Anhaltender Husten""
                },
                {
                    ""id"": ""aRhinitis"",
                    ""text"": ""Schnupfen""
                },
                {
                    ""id"": ""aDiarrhea"",
                    ""text"": ""Durchfall""
                },
                {
                    ""id"": ""aSoreThroat"",
                    ""text"": ""Halsschmerzen""
                },
                {
                    ""id"": ""aHeadache"",
                    ""text"": ""Kopfschmerzen""
                }
            ]
        },
        {
            ""id"": ""qShortnessOfBreath"",
            ""type"": ""radio"",
            ""question"": ""Sind Sie in den letzten 24 Std. schneller außer Atem als sonst?"",
            ""comment"": ""Wählen Sie \""Ja\"", wenn Sie:\n        Bei leichten Belastungen, wie einem Spaziergang oder dem Steigen weniger Treppenstufen schneller als sonst kurzatmig werden oder Schwierigkeiten beim Atmen haben\n        Das Gefühl der Atemnot/Luftnot oder Kurzatmigkeit beim Sitzen oder Liegen verspüren\n        Beim Aufstehen aus dem Bett oder vom Stuhl das Gefühl der Atemnot/Luftnot haben\n\n\n        Sollten Sie eine chronische Lungenerkrankung haben, vergleichen Sie Ihre derzeitigen Beschwerden im Hinblick auf Ihre Atmung mit Ihren bisherigen Atemproblemen."",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                }
            ]
        },
        {
            ""id"": ""qSymptomDate"",
            ""type"": ""date"",
            ""depends"": {
                ""any"": [
                    {
                        ""questionId"": ""qFever24h"",
                        ""answerId"": ""aYes""
                    },
                    {
                        ""questionId"": ""qFever4d"",
                        ""answerId"": ""aYes""
                    },
                    {
                        ""questionId"": ""qSymptoms24h1"",
                        ""answerId"": ""aShivering""
                    },
                    {
                        ""questionId"": ""qSymptoms24h1"",
                        ""answerId"": ""aAchingLimbs""
                    },
                    {
                        ""questionId"": ""qSymptoms24h1"",
                        ""answerId"": ""aLossOfTasteOrSmell""
                    },
                    {
                        ""questionId"": ""qSymptoms24h2"",
                        ""answerId"": ""aFatigue""
                    },
                    {
                        ""questionId"": ""qSymptoms24h2"",
                        ""answerId"": ""aCough""
                    },
                    {
                        ""questionId"": ""qSymptoms24h2"",
                        ""answerId"": ""aRhinitis""
                    },
                    {
                        ""questionId"": ""qSymptoms24h2"",
                        ""answerId"": ""aDiarrhea""
                    },
                    {
                        ""questionId"": ""qSymptoms24h2"",
                        ""answerId"": ""aSoreThroat""
                    },
                    {
                        ""questionId"": ""qSymptoms24h2"",
                        ""answerId"": ""aHeadache""
                    },
                    {
                        ""questionId"": ""qShortnessOfBreath"",
                        ""answerId"": ""aYes""
                    }
                ]
            },
            ""question"": ""Bezogen auf alle Fragen zu Symptomen: Seit wann haben Sie die von Ihnen angegebenen Symptome?""
        },
        {
            ""id"": ""qChronicalPulmonaryDisease"",
            ""type"": ""radio"",
            ""question"": ""Wurde bei Ihnen durch eine Ärztin/einen Arzt eine chronische Lungenerkrankung festgestellt?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                },
                {
                    ""id"": ""aNoIdea"",
                    ""text"": ""Ich weiß es nicht""
                }
            ]
        },
        {
            ""id"": ""qDiabetes"",
            ""type"": ""radio"",
            ""question"": ""Wurde bei Ihnen durch eine Ärztin/einen Arzt Diabetes festgestellt?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                },
                {
                    ""id"": ""aNoIdea"",
                    ""text"": ""Ich weiß es nicht""
                }
            ]
        },
        {
            ""id"": ""qHeartDisease"",
            ""type"": ""radio"",
            ""question"": ""Wurde bei Ihnen durch eine Ärztin/einen Arzt eine Herzerkrankung festgestellt?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                },
                {
                    ""id"": ""aNoIdea"",
                    ""text"": ""Ich weiß es nicht""
                }
            ]
        },
        {
            ""id"": ""qObesity"",
            ""type"": ""radio"",
            ""question"": ""Wurde bei Ihnen durch eine Ärztin/einen Arzt Adipositas (Fettsucht) festgestellt?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                },
                {
                    ""id"": ""aNoIdea"",
                    ""text"": ""Ich weiß es nicht""
                }
            ]
        },
        {
            ""id"": ""qCortisoneAsPills"",
            ""type"": ""radio"",
            ""question"": ""Nehmen Sie aktuell Cortison in Tablettenform ein?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                },
                {
                    ""id"": ""aNoIdea"",
                    ""text"": ""Ich weiß es nicht""
                }
            ]
        },
        {
            ""id"": ""qImmunosuppressiveDrugs"",
            ""type"": ""radio"",
            ""question"": ""Nehmen Sie aktuell Immunsuppressiva ein?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                },
                {
                    ""id"": ""aNoIdea"",
                    ""text"": ""Ich weiß es nicht""
                }
            ]
        },
        {
            ""id"": ""qFluShotThisSeason"",
            ""type"": ""radio"",
            ""question"": ""Haben Sie sich im Zeitraum vom 1. August 2020 bis heute gegen Grippe impfen lassen?"",
            ""answers"": [
                {
                    ""id"": ""aYes"",
                    ""text"": ""Ja""
                },
                {
                    ""id"": ""aNo"",
                    ""text"": ""Nein""
                }
            ]
        }
    ]
}
";

        #endregion

        static void Main()
        {
            var answers = GetAnswers();

            var results = GetResults(answers);

            Console.WriteLine($"Ihr Score für die Vortestwahrscheinlichkeit ist {results.PreTestProbabilityScore}");
            Console.WriteLine($"Ihr Score für das epidemische Risiko ist {results.EpidemicRiskScore}");
            Console.WriteLine($"Ihr Score für das Risiko auf einen schweren Verlauf ist {results.SevereCaseRiskScore}");

            if (results.ShowSingleWarning)
                Console.WriteLine("Halten Sie täglich telefonischen Kontakt zu Angehörigen");
            else if (results.ShowGroupWarning)
                Console.WriteLine("Halten Sie Abstand zu Ihren Mitbewohnern");

            if (results.ShowShortnessOfBreathWarning)
                Console.WriteLine("Bei Plötzlich auftretender Atemnot sollten Sie sofort von einem Arzt untersucht werden");
        }

        private static Dictionary<string, Answer> GetAnswers()
        {
            var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            var model = JsonSerializer.Deserialize<Model>(QuestionJson, options)!;

            var answers = new Dictionary<string, Answer>();
            foreach (var question in model.Questions)
            {
                if (ShowQuestion(question.Depends))
                {
                    var answer = GetAnswer(question);
                    answers.Add(answer.QuestionId, answer);
                }
            }

            bool ShowQuestion(Dependency? dependency)
            {
                if (dependency == null)
                    return true;
                if (dependency.AnswerId != null && IsDependencyFulfilled(dependency))
                    return true;
                if (dependency.Any == null)
                    return false;

                foreach (var option in dependency.Any)
                {
                    if (option.Any != null)
                        throw new FormatException("Nested any dependencies are not supported.");
                    if (option.AnswerId == null)
                        throw new FormatException("Dependency without answer id.");
                    if (IsDependencyFulfilled(option))
                        return true;
                }

                return false;

                bool IsDependencyFulfilled(Dependency dep)
                {
                    if (!answers.ContainsKey(dep.QuestionId))
                        return false;
                    var answer = answers[dep.QuestionId];
                    switch (answer)
                    {
                        case RadioAnswer ra:
                            return ra.AnswerId == dep.AnswerId;
                        case CheckAnswer ca:
                            return ca.AnswerIds.Contains(dep.AnswerId!);
                        default:
                            return false;
                    }
                }
            }

            static Answer GetAnswer(Question q)
            {
                Console.Clear();
                Console.WriteLine(q.QuestionText);
                Console.WriteLine();
                switch (q.Type)
                {
                    case QuestionType.Radio:
                        for (var index = 0; index < q.Answers.Count; index++)
                        {
                            var answer = q.Answers[index];
                            Console.WriteLine(answer.Text + $" [{index}]");
                        }
                        int selectedIndex;

                        while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out selectedIndex) || selectedIndex >= q.Answers.Count){}

                        var selectedAnswerId = q.Answers[selectedIndex].Id;
                        return new RadioAnswer(q.Id, selectedAnswerId);
                    case QuestionType.Check:
                        var checkedIndexes = new List<int>();
                        for (var index = 0; index < q.Answers.Count; index++)
                        {
                            var answer = q.Answers[index];
                            Console.Write(answer.Text + " [J/N] ");
                            bool? isChecked = null;
                            while (!isChecked.HasValue)
                                isChecked = Console.ReadKey(true).KeyChar switch {'J' => true, 'j' => true, 'N' => false, 'n' => false, _ => null};

                            Console.WriteLine();
                            if (isChecked.Value)
                                checkedIndexes.Add(index);
                        }

                        return new CheckAnswer(q.Id, GetCheckedAnswerIds());

                        IEnumerable<string> GetCheckedAnswerIds()
                        {
                            foreach (var index in checkedIndexes)
                                yield return q.Answers[index].Id;
                        }

                        break;
                    case QuestionType.Date:
                        Console.Write($"[{CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern}] ");
                        DateTime value;
                        while (!DateTime.TryParseExact(Console.ReadLine(), CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern, CultureInfo.CurrentUICulture, DateTimeStyles.None, out value)) { }

                        return new DateAnswer(q.Id, value);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return answers;
        }

        private static CovAppResult GetResults(Dictionary<string, Answer> answers)
        {
            CovAppResult results = new CovAppResult();
            results.SevereCaseRisk +=
                Ra("qAge") switch {"a61to70" => 1, "a71to80" => 2, "aGt80" => 3, _ => 0};

            if (Ra("qCare") == "aYes")
                results.EpidemicRisk++;

            if (Ra("qProfession") != "aNone")
            {
                results.EpidemicRisk++;
                results.PreTestProbability++;
            }

            if (Ra("qSmoking") == "aYes")
                results.SevereCaseRisk++;

            if (Ra("qPregnant") == "aYes")
                results.SevereCaseRisk++;

            if (Ra("qContact") == "aYes")
                results.EpidemicRisk++;

            var shortnessOfBreath = Ra("qShortnessOfBreath") == "aYes";

            if (shortnessOfBreath)
            {
                results.SevereCaseRisk += 2;
                results.ShowShortnessOfBreathWarning = true;
            }

            if (shortnessOfBreath || Ra("qFever24h") == "aYes" || Ra("qFever4d") == "aYes" || Ca("qSymptoms24h1").Count > 0 || Ca("qSymptoms24h2").Count > 0)
                results.PreTestProbability++;

            if (Ca("qSymptoms24h1").Contains("aLossOfTasteOrSmell"))
                results.PreTestProbability += 2;

            if (Ra("qChronicalPulmonaryDisease") == "aYes")
                results.SevereCaseRisk++;

            if (Ra("qDiabetes") == "aYes")
                results.SevereCaseRisk++;

            if (Ra("qHeartDisease") == "aYes")
                results.SevereCaseRisk++;

            if (Ra("qObesity") == "aYes")
                results.SevereCaseRisk++;

            if (Ra("qCortisoneAsPills") == "aYes")
                results.SevereCaseRisk++;

            if (Ra("qImmunosuppressiveDrugs") == "aYes")
                results.SevereCaseRisk++;

            if (Ra("qFluShotThisSeason") == "aYes")
                results.PreTestProbability++;

            if (Ra("qLivingSituation") == "aSingle")
            {
                if (results.SevereCaseRisk > 0)
                    results.ShowSingleWarning = true;
            }
            else if (results.PreTestProbability > 0)
                results.ShowGroupWarning = true;

            return results;

            string Ra(string questionId) => (answers[questionId] as RadioAnswer)!.AnswerId;
            List<string> Ca(string questionId) => (answers[questionId] as CheckAnswer)!.AnswerIds;
        }
    }
}
