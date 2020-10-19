
namespace Excel
{
    static class Constants
    {
        public const string HelpMsg = "Привіт!\n" +
            "Даний застосунок є аналогом Excel, " +
            "зроблений Алєксєєнко Анною з групи К-26. " +
            "Тут Ви зможете обчислити вираз (допускаються арифметичні оператори, " +
            "унарні + та -, mod, div, ^, також можна посилатися на комірки таблиці, " +
            "використовуючи синтаксис [стовпчик][рядок]), " +
            "додавати та видаляти рядки й стовпчики, зберегти результат у файл, а " +
            "згодом імпортувати його.";

        public const string ConfirmExitMsg = "Ви впевнені, що хочете вийти?";

        public const string ConfirmExitHeader = "Вихід";

        public const string IncorrectExprMsg = "Некоректний вираз";

        public const string Loop = "Присутній цикл. Вираз некоректний";

        public const string ConfirmImportMsg = "Ви дійсно хочете імпортувати новий файл? " +
            "Всі Ваші зміни буде втрачено";

        public const string ConfirmImportHeader = "Підтвердіть зміни";

        public const string NullCellWarning = "Такої клітинки немає";

        public const string DeleteDependenciesMsg = "Неможливо видалити клітинку. " +
            "Наявні залежності";
    }
}
