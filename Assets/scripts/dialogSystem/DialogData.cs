using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialogData{
  public static DialogDataClass[] FirstScene = {
    new DialogDataClass(
      "Ваш корабль поврежден, нужен срочный ремонт",
      Roles.CAPTAIN,
      Resources.Load<AudioClip>("audio/капитан/ваш корабль поврежден")
    ),
    new DialogDataClass(
      "Жду подробностей повреждения",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/жду подробностей повреждения")
    ),
    new DialogDataClass(
      "Подробности высланы вам на почту, проверьте",
      Roles.CAPTAIN,
      Resources.Load<AudioClip>("audio/капитан/подробности высланы")
    )
  };

  public static DialogDataClass[] SecondSceneFirstAction = {
    new DialogDataClass(
      "Файл доставлен, в нем обнаружены повреждения",
      Roles.VOICE_ASSISTANT,
      Resources.Load<AudioClip>("audio/голосовой помощник/Файл доставлен")
    ),
    new DialogDataClass(
      "О черт, опять этот баг, надо будет написать админам чтобы уже наконец исправили проблемы с кодировками. Ладно, давай посмотрим, что тут случилось",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/о черт, опять этот баг")
    )
  };
  public static DialogDataClass[] SecondSceneSecondAction = {
    new DialogDataClass(
      "В этот раз файл поврежден очень сильно, надо его открыть и посмотреть что в нем сохранилось",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/в этот раз файл порвежден очень сильно")
    ),
  }; 
  public static DialogDataClass[] ThirdSceneAction = {
    new DialogDataClass(
      "Elizabeth, сделай анализ утечек",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/сделай анализ утечек")
    ),
    new DialogDataClass(
      "Утечки в гиперпространстве, чтобы восстановить исходный файл вам надо немного помучаться",
      Roles.VOICE_ASSISTANT,
      Resources.Load<AudioClip>("чтобы восстановить файл")
    ),
    new DialogDataClass(
      "Пилот, мы приготовили тебе последнее твое задание, после которого мы все рискуем умереть и погубить весь экипаж, либо ты станешь настоящим специалистом своего дела и будешь командовать отделом",
      Roles.CAPTAIN,
      Resources.Load<AudioClip>("audio/капитан/пилот, мы приготовили твое задание")
    ),
    new DialogDataClass(
      "Какое задание?",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/какое задание")
    ),
    new DialogDataClass(
      "Устрани неисправности на корабле, тогда ты докажешь свой профессионализм",
      Roles.CAPTAIN,
      Resources.Load<AudioClip>("audio/капитан/устрани неисправности")
    ),
    new DialogDataClass(
      "Есть",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/есть")
    )
  };
  public static DialogDataClass[] FourthSceneFirstAction = {
    new DialogDataClass(
      "Для этого мне нужна карта корабля с нанесенными повреждениями, а она как назло не пришла в чистом виде, да еще это гиперпространство...",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/для этого мне нужна карта корабля")
    )
  };
  public static DialogDataClass[] FourthSceneSecondAction = {
    new DialogDataClass(
      "Точно, это двигательный отсек, в нем вечно происходят проблемы, но я не помню код от этого щитка",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/Точно это двигательный отсек")
    ),
    new DialogDataClass(
      "Ты на правильном пути, ученик мой, разгадай эту загадку тогда ты откроешь щиток",
      Roles.CAPTAIN,
      Resources.Load<AudioClip>("audio/капитан/ты на правильном пути")
    )
  };
  public static DialogDataClass[] FourthSceneThirdAction = {
    new DialogDataClass(
      "Молодец, ты открыл щиток",
      Roles.CAPTAIN,
      Resources.Load<AudioClip>("audio/капитан/молодец, ты открыл щиток")
    ),
    new DialogDataClass(
      "Спасибо, кэп",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/спасибо, кэп")
    ),
    new DialogDataClass(
      "О, кажется я нашел кусок файла, странно, как он мог затеряться в реальном мире, надо будет сообщить админам",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/О, кажется я нашел кусок файла")
    )
  };
  public static DialogDataClass[] FourthSceneFourthAction = {
    new DialogDataClass(
      "Отлично, давай посмотрим карту",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/Отлично, давай посмотрим карту")
    )
  };
  public static DialogDataClass[] FourthSceneFiftAction = {
    new DialogDataClass(
      "Здесь указано, куда идти, надо попробовать",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/Здесь указано куда идти")
    )
  };
  public static DialogDataClass[] FiftSceneAction = {
    new DialogDataClass(
      "Наконец-то я пришел к двигателю....но кажется есть проблема, тут очень темно, надо вернуться за фонариком",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/наконец-то я пришел к двигателю")
    )
  };
  public static DialogDataClass[] SixthSceneFirstAction = {
    new DialogDataClass(
      "Тааак, где тут фонарик? я его прятал где-то в ящиках, но их тут просто очень много, как мне их все посмотреть?",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/таак, где тут фонарик")
    ),
    new DialogDataClass(
      "Ты умрешь и погубишь весь экипаж",
      Roles.CAPTAIN_IN_IMAGINATION,
      Resources.Load<AudioClip>("audio/капитан/устрани неисправности")
    ),
    new DialogDataClass(
      "Надо срочно действовать, помоги мне найти среди этих ящиков фонарь",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/Надо срочно действовать")
    ),
  };
  public static DialogDataClass[] SixthSceneSecondAction = {
    new DialogDataClass(
      "О, мы нашли фонарь, теперь давай скорее бежать чинить двигатель, хотя..",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/О мы нашли фонарь")
    ),
    new DialogDataClass(
      "Утечки в гиперпространстве, чтобы восстановить исходный файл вам придется НеМнОгО ПоМуЧаТьСя",
      Roles.VOICE_ASSISTANT_IN_IMAGINATION,
      Resources.Load<AudioClip>("audio/голосовой помощник/чтобы восстановить файл")
    ),
    new DialogDataClass(
      "Я совсем забыл, я же не знаю где поломка, а без нее я не смогу починить корабль, попробуй найти кусок карты в тех же ящиках что ты искал фонарь, может он затаился там",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/Я совсем забыл, я же не знаю где поломка")
    )
  };
  public static DialogDataClass[] SixthSceneThirdAction = {
    new DialogDataClass(
      "ООО, вот и кусок карты",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/О, вот и кусок карты")
    )
  };
  public static DialogDataClass[] SixthSceneFourthAction = {
    new DialogDataClass(
      "Посмотри, теперь мы можем видеть, где поломка у корабля, пойдем скорее к двигателю и починим корабль.",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/Смотри, теперь мы можем видеть, где поломка у корабля")
    )
  };
  public static DialogDataClass[] SeventhSceneFirstAction = {
    new DialogDataClass(
      "Вот, мы у двигателя, все видно, в карте есть информация по поломке, дело за малым - починить двигатель. Хммм, но тут нужен явно гаечный ключ, надо открутить вот этот щиток.",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/Вот мы у двигателя")
    ),
    new DialogDataClass(
      "О нет, у нас совсем мало времени. Надо что-то срочно предпринять.",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/о нет, у нас совсем мало времени")
    )
  };
  public static DialogDataClass[] SeventhSceneSecondAction = {
    new DialogDataClass(
      "Хмм, что это за ящик, вечно этот штурман  забудет что-нибудь убрать.  Попробую открыть его, тут какая-то головоломка.",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/мм, что это за ящик")
    ),
  };
  public static DialogDataClass[] SeventhSceneThirdAction = {
    new DialogDataClass(
      "Тут как раз есть ключ, надо его взять",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/тут как раз есть ключ, надо его взять")
    ),
  };
  public static DialogDataClass[] EightScene = {
    new DialogDataClass(
      "Фух, получилось",
      Roles.PILOT,
      Resources.Load<AudioClip>("audio/пилот/Фух, получилось")
    ),
    new DialogDataClass(
      "Поздравляю, ты справился, я напишу приказ чтобы тебя повысили",
      Roles.CAPTAIN,
      Resources.Load<AudioClip>("audio/капитан/поздравля, ты справился")
    )
  };
}


public struct DialogDataClass {
  public string text;
  public Roles role;
  public AudioClip audio;
  public DialogDataClass(string text, Roles role, AudioClip audio) {
    this.text = text;
    this.role = role;
    this.audio = audio;
  }
}