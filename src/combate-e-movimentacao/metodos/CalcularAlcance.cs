class Combate{
    public static string CalcularAlcance(int px, int py, int ex, int ey)
    {
        int distX = Math.Abs(px - ex);
        int distY = Math.Abs(py - ey);
        int distancia = distX + distY; // Distância Manhattan

        if (distancia <= 2) return "curto";
        if (distancia <= 5) return "medio";
        return "longo";
    }
}