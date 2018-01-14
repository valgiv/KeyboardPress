using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using KeyboardPress_Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardPress_Analyzer.Functions
{
    public class OfferWord
    {
        private KeyValuePair<string, string>[] offerWordTemplate_pairs;
        private NotifyIcon ow_notifyIcon;

        public OfferWord(NotifyIcon ni)
        {
            if (ni == null)
                throw new ArgumentNullException(nameof(ni));

            ow_notifyIcon = ni;

            offerWordTemplate_pairs = new KeyValuePair<string, string>[] // to do: iskelti i db
            {
                new KeyValuePair<string, string>("aa", "labaaaasRytas"),
                new KeyValuePair<string, string>("abrikosas", "ananasas"),
                new KeyValuePair<string, string>("ilgiausias", "pasikiškekopūsteliaudavome")
            };

            
        }

        private bool needHideMsg = false;
        public void offerWordTemplate(ObjEvent_key[] NLastKeyPressInSameWindow)
        {
            try
            {
                if (offerWordTemplate_pairs != null && offerWordTemplate_pairs.Count() > 0)
                {
                    int maxLettersToCheck = 10;
                    int symbolToConfimOffer = 9;//// tab '\t'
                    bool confirm = NLastKeyPressInSameWindow[NLastKeyPressInSameWindow.Length - 1].KeyValue == symbolToConfimOffer;

                    string lastSymbols = "";
                    foreach (var s in NLastKeyPressInSameWindow)
                    {
                        lastSymbols += s.Key.ToString();
                    }
                    if (confirm)
                    {
                        lastSymbols = lastSymbols.Remove(lastSymbols.Length - 1, 1);
                    }
                    for (int i = 1; i < maxLettersToCheck && i < lastSymbols.Length; i++)
                    {
                        string strLet = lastSymbols.Remove(0, lastSymbols.Length - 1 - i);
                        var pair = offerWordTemplate_pairs.FirstOrDefault(x => x.Key.ToLower() == strLet.ToLower());
                        if (!String.IsNullOrEmpty(pair.Key) && !String.IsNullOrEmpty(pair.Value))
                        {
                            if (!confirm)
                            {
                                ow_notifyIcon.ShowBalloonTip(1000, "", $"Siūlomas tekstas: {pair.Value}", ToolTipIcon.Info); // nice to have: reikia pamastyti kaip uzdaryti siulymus
                                needHideMsg = true;
                                //System.Diagnostics.Debug.WriteLine("offerWordTemplate atitikmuo: " + pair.Value);
                                return;
                            }
                            else
                            {
                                System.Windows.Forms.Application.DoEvents();
                                KeyboardControlAdapter.pressAndReleaseButton(VirtualKeysEnum.VK_BACK);
                                for (int z = 0; z < ((KeyValuePair<string, string>)pair).Key.Length; z++)
                                {
                                    KeyboardControlAdapter.pressAndReleaseButton(VirtualKeysEnum.VK_BACK);
                                }
                                KeyboardControlAdapter.pasteText(((KeyValuePair<string, string>)pair).Value, true);

                                return;
                            }
                        }
                        else
                        {
                            if (needHideMsg)
                            {
                                ow_notifyIcon.HideBalloonTip();
                                needHideMsg = false;
                            }
                        }
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                return;
            }
        }
    }
}
