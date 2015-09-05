using System;

namespace Fwk.Bases
{
    interface IFwkHistory
    {
        bool CanRedo { get; }
        bool CanUndo { get; }
        void Redo();
        void Undo();
    }
}
