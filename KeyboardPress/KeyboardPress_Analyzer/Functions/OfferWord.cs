using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using KeyboardPress_Extensions;
using KeyboardPress_Extensions.InfoForm;
using System;
using System.Collections.Generic;
using System.Data;
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

        //nice to have: padaryti siulymu/panaudotų siūlymų skaiciavima

        public OfferWord(NotifyIcon ni)
        {
            if (ni == null)
                throw new ArgumentNullException(nameof(ni));

            ow_notifyIcon = ni;
            
            load_offerWordTemplate_pairs();
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
                                //ow_notifyIcon.ShowBalloonTip(1000, "", $"Siūlomas tekstas: {pair.Value}", ToolTipIcon.Info); // nice to have: reikia pamastyti kaip uzdaryti siulymus
                                //needHideMsg = true;
                                //
                                InfoForm.Show($"Siūlomas tekstas: {pair.Value}",
                                   "Siūlymas", 2000,
                                   InfoForm.Enum_InfoFormImage.Precent,
                                   null);
                                //
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
                            //if (needHideMsg)
                            //{
                            //    ow_notifyIcon.HideBalloonTip();
                            //    needHideMsg = false;
                            //}
                            // nice to have: išjungti InfoForm.Show pasiūlymo rodymą
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

        private void load_offerWordTemplate_pairs()
        {
            try
            {
                var dt = Helper.DBHelper.GetDataTableDb($"SELECT value1, value2 FROM KP_OFFER_WORD WHERE user_record_id = {DBHelper.UserId}");
                if(dt != null && dt.Rows.Count > 0)
                {
                    List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
                    foreach(DataRow item in dt.Rows)
                    {
                        lst.Add(new KeyValuePair<string, string>(item["value1"].ToString(), item["value2"].ToString()));
                    }
                    offerWordTemplate_pairs = lst.ToArray();
                }
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
            }
        }

        public void reloadOfferWord()
        {
            load_offerWordTemplate_pairs();
        }
    }
}
