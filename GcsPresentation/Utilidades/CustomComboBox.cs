﻿using GcsPresentation.Utilidades.Objetos;

namespace GcsPresentation.Utilidades
{
    public static class CustomComboBox
    {
        public static void InsertarItems(this ComboBox combo, OpcionCombo[]items)
        {
            combo.Items.AddRange(items);
            combo.DisplayMember = "Texto";
            combo.ValueMember = "Valor";
            combo.SelectedIndex = 0;
        }
    }
}