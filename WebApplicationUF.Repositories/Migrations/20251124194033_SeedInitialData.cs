using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfrastructureUF.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Capital", "Descricao", "Nome", "Regiao", "Sigla" },
                values: new object[,]
                {
                    { 1, "Rio Branco", "Estado na Região Norte...", "Acre", "Norte", "AC" },
                    { 2, "Maceió", "Estado do Nordeste...", "Alagoas", "Nordeste", "AL" },
                    { 3, "Macapá", "Estado na Região Norte...", "Amapá", "Norte", "AP" },
                    { 4, "Manaus", "O maior estado do Brasil...", "Amazonas", "Norte", "AM" },
                    { 5, "Salvador", "Estado do Nordeste, centro da cultura afro-brasileira...", "Bahia", "Nordeste", "BA" },
                    { 6, "Fortaleza", "Estado nordestino conhecido pelas suas famosas dunas...", "Ceará", "Nordeste", "CE" },
                    { 7, "Brasília", "Onde se localiza Brasília...", "Distrito Federal", "Centro-Oeste", "DF" },
                    { 8, "Vitória", "Estado da Região Sudeste...", "Espírito Santo", "Sudeste", "ES" },
                    { 9, "Goiânia", "Localizado no Centro-Oeste...", "Goiás", "Centro-Oeste", "GO" },
                    { 10, "São Luís", "Estado do Nordeste com o Parque Nacional dos Lençóis Maranhenses...", "Maranhão", "Nordeste", "MA" },
                    { 11, "Cuiabá", "Estado do Centro-Oeste...", "Mato Grosso", "Centro-Oeste", "MT" },
                    { 12, "Campo Grande", "Famoso pela região do Pantanal...", "Mato Grosso do Sul", "Centro-Oeste", "MS" },
                    { 13, "Belo Horizonte", "Estado da Região Sudeste...", "Minas Gerais", "Sudeste", "MG" },
                    { 14, "Belém", "Estado da Região Norte...", "Pará", "Norte", "PA" },
                    { 15, "João Pessoa", "Estado nordestino famoso pelo ponto mais oriental das Américas...", "Paraíba", "Nordeste", "PB" },
                    { 16, "Curitiba", "Estado da Região Sul...", "Paraná", "Sul", "PR" },
                    { 17, "Recife", "Estado do Nordeste...", "Pernambuco", "Nordeste", "PE" },
                    { 18, "Teresina", "Estado do Nordeste...", "Piauí", "Nordeste", "PI" },
                    { 19, "Rio de Janeiro", "Famoso no mundo todo por suas praias...", "Rio de Janeiro", "Sudeste", "RJ" },
                    { 20, "Natal", "Estado nordestino com o litoral repleto de dunas...", "Rio Grande do Norte", "Nordeste", "RN" },
                    { 21, "Porto Alegre", "Estado da Região Sul...", "Rio Grande do Sul", "Sul", "RS" },
                    { 22, "Porto Velho", "Estado da Região Norte...", "Rondônia", "Norte", "RO" },
                    { 23, "Boa Vista", "O estado mais setentrional do Brasil...", "Roraima", "Norte", "RR" },
                    { 24, "Florianópolis", "Estado da Região Sul...", "Santa Catarina", "Sul", "SC" },
                    { 25, "São Paulo", "O estado mais populoso e rico do Brasil...", "São Paulo", "Sudeste", "SP" },
                    { 26, "Aracaju", "O menor estado do Brasil...", "Sergipe", "Nordeste", "SE" },
                    { 27, "Palmas", "O estado mais jovem do Brasil...", "Tocantins", "Norte", "TO" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 27);
        }
    }
}
