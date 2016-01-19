using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace IDE {
    class CustomTextBox:System.Windows.Forms.RichTextBox {
        public const int WM_VSCROLL = 0x115;
        public const int WM_HSCROLL = 0x114;
        public const int WM_MOUSEWHEEL = 0x20A;
        public const int WM_COMMAND = 0x111;
        public const int WM_USER = 0x400;

        List<CustomTextBox> peers = new List<CustomTextBox>();

        public void AddPeer(CustomTextBox peer) {
            this.peers.Add(peer);
        }

        public void DirectWndProc(ref Message m) {
            base.WndProc(ref m);
        }

        protected override void WndProc(ref Message m) {
            var j= m;
            if (new int[]{ WM_VSCROLL,WM_HSCROLL,WM_MOUSEWHEEL,WM_USER,WM_COMMAND }.Any((s)=>s == j.Msg)) {
                foreach (var peer in this.peers) {
                    var peerMessage = Message.Create(peer.Handle, m.Msg, m.WParam, m.LParam);
                    peer.DirectWndProc(ref peerMessage);
                }
            }

            base.WndProc(ref m);
        }
    }
}
