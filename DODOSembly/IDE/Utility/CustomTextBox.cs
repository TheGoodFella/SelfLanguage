using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace IDE {
    class CustomTextBox:System.Windows.Forms.RichTextBox {
        private const int WM_VSCROLL = 0x115;
        private const int WM_MOUSEWHEEL = 0x20A;
        private const int WM_USER = 0x400;
        private const int SB_VERT = 1;
        private const int EM_SETSCROLLPOS = WM_USER + 222;
        private const int EM_GETSCROLLPOS = WM_USER + 221;
        private List<int> lst = new List<int>();

        List<CustomTextBox> peers = new List<CustomTextBox>();

        public void AddPeer(CustomTextBox peer) {
            this.peers.Add(peer);
        }

        public void DirectWndProc(ref Message m) {
            base.WndProc(ref m);
        }

        protected override void WndProc(ref Message m) {
            var j= m;
            if (!lst.Contains(m.Msg)) {
                lst.Add(m.Msg);
            }
            if (new int[] { WM_VSCROLL, WM_MOUSEWHEEL, WM_USER, SB_VERT, EM_SETSCROLLPOS, EM_GETSCROLLPOS }.Any((s) => s == j.Msg)) {
                foreach (var peer in this.peers) {
                    var peerMessage = Message.Create(peer.Handle, m.Msg, m.WParam, m.LParam);
                    peer.DirectWndProc(ref peerMessage);
                }
            }

            base.WndProc(ref m);
        }
        public CustomTextBox() {
            lst.AddRange((new int[] { }));
        }
    }
}
