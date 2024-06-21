using CHARACTERS;
using DIALOGUE;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConversationDialogueManager : MonoBehaviour
{
    private Character CreateCharacter(string name) => CharacterManager.instance.CreateCharacter(name);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Prolog());
    }

    IEnumerator Prolog()
    {
        AudioManager.Instance.StopMusic();

        Character Narrator = CreateCharacter("Narrator");
        Character Grandpa = CreateCharacter("Grandpa");
        Character Buyer = CreateCharacter("Buyer");
        Character_Sprite Arkan = CreateCharacter("Arkan") as Character_Sprite;
        Character_Sprite HidJoko = CreateCharacter("??? as Joko") as Character_Sprite;
        Character_Sprite Joko = CreateCharacter("Joko") as Character_Sprite;
        Character_Sprite Dad = CreateCharacter("Father") as Character_Sprite;
        Character_Sprite Mom = CreateCharacter("Mother") as Character_Sprite;
        Character_Sprite Chief = CreateCharacter("Village Chief") as Character_Sprite;
        Character_Sprite Dayana = CreateCharacter("Dayana") as Character_Sprite;
        Character_Sprite HidAunt = CreateCharacter("???? as Gossip Aunt") as Character_Sprite;
        Character_Sprite Aunt = CreateCharacter("Gossip Aunt") as Character_Sprite;
        Character_Sprite Maman = CreateCharacter("Maman") as Character_Sprite;

        yield return Narrator.Say("I suddenly remembered.{c}About the promise that I've made 5 years ago.{c}Together with my Grandpa.");

        GraphicPanel panel = GraphicPanelManager.instance.GetPanel("Background");
        GraphicLayer layer0 = panel.GetLayer(0, true);

        Texture topDown = Resources.Load<Texture>("Graphics/Transition Effects/topDown");
        Texture leftRight = Resources.Load<Texture>("Graphics/Transition Effects/leftRight");
        Texture rightLeft = Resources.Load<Texture>("Graphics/Transition Effects/rightLeft");
        Texture sidesToCenter = Resources.Load<Texture>("Graphics/Transition Effects/sides");

        layer0.SetTexture("Graphics/BG Images/desk lamp");
        AudioManager1.instance.PlayTrack("Audio/Music/Visual Novel/calm and peaceful", loop: true, volumeCap: 0.7f);

        yield return Grandpa.Say("You want me to tell you the story about my adventure again, Arkan?");

        yield return Arkan.Say("That's right!");

        yield return Grandpa.Say("Hahaha{wa 1}, you've listened to it countless times already. Don't you feel bored?");

        yield return Arkan.Say("Of course not!");

        List<string> lines = new List<string>()
        {
            "I shake my head violently.",
            "Back then, I adored my Grandfather so much that I've always begged him to tell me about his adventure as the master angler.",
            "After all,{wa 0.5} ever since I was a child,{wa 0.5} I have always seen my grandfather on TV, being the famous Master Angler who managed to fight with the legendary fishes all around the world.{c}His experience and knowledge are widely spread among other master anglers.",
            "No matter whether it's old or young, my grandfather's feat is widely known to all Anglers.",
            "That's one of the reasons why I adore him so much.",
            "After all, which kid won't feel proud if their grandfather is so awesome?"
        };

        yield return Narrator.Say(lines);

        yield return Arkan.Say("I like to listen about it. I won't get bored.{a} After all, I dream of becoming the best master angler like you! No,{wa 1} even surpassed you!");

        List<string> lines2 = new List<string>()
        {
            "Haha, {wa 1}I'm not as good as you think.",
            "After all...{a} I can't even catch that legendary figure. {wa 1}My title as 'The Best Master Angler of the World' is nothing but faux.",
        };

        yield return Grandpa.Say(lines2);

        yield return Arkan.Say("Ah.{c}ItÅfs that fish again.");

        List<string> lines3 = new List<string>()
        {
            "Back then, each time Grandpa talked about that fish, he always wore a bitter smile on his face.",
            "His eyes are complicated.{c}It's full of nostalgia and regret.{c}After all, {wa 0.5}I heard from my Dad that before Grandpa retired as a master angler due to an accident in his leg,{wa 0.5} that fish was the last legendary fish that grandfather tried to catch.",
            "Seeing Grandpa like that making me can't help but to make that promise.{wc 1}A promise that changed my life."
        };

        yield return Narrator.Say(lines3);

        yield return Arkan.Say("Then, as long as I catch that legendary fish, does that mean I managed to surpass you, Grandpa?");

        yield return Arkan.Say("Alright! I've decided. From now on, my goal is to catch that legendary fish!");

        yield return Grandpa.Say("!!!");

        yield return Narrator.Say("back then, my Grandpa shows a surprised expression. His wrinkled face showed a bit of disbelief,{wa 1} as if asking me how my train of thought could reach to that conclusion.");

        yield return Grandpa.Say("No no no. How did you suddenly think something like that? {a}That fish is different from the other fish. She can't be caught!");

        yield return Arkan.Say("Why not?{a} As long as it's a fish, it can be caught!{a} That's the first rule of Master Angler.{c}Then,{wa 0.5} as long I train myself, I can definitely catch that fish!");

        yield return Narrator.Say("Grandpa shake his head violently.");

        List<string> lines4 = new List<string>()
        {
            "You don't understand, Arkan. The reason why I can't catch that fish is because she's cunning. That fish can swim so deep under the lake and she usually hides if she feels the presence of others.",
            "Moreover, her intelligence is as high as human. Do you know that back then, me and my friends all thought that weÅfd managed to catch her, but she somehow managed to maneuver around and broke fishing gear?",
            "Arkan, as your Grandfather, I approve your ambition to surpass me, but! Trying to catch that fish is something beyond impossible! {c}I suggest you choose another goal to achieve. DonÅft spend your time to catch that fish. Because I suspect that sheÅfs a deity who took the form of a fish."
        };

        yield return Grandpa.Say(lines4);

        List<string> lines5 = new List<string>()
        {
            "No, Grandpa. I still want to catch that fish. You once said that Angler is a profession full of challenges and built from failures. Every time an angler fails to catch a fish, they will learn from their mistake and try to overcome it.",
            "Even if it will take a long time, I will still try to catch that fish.",
            "After all, Grandpa was always so sad every time the fish was brought up, I donÅft like it. So Grandpa, please teach me how to become a Master Angler like you! I promise I will definitely catch that fish for you!"
        };

        yield return Arkan.Say(lines5);

        List<string> lines6 = new List<string>()
        {
            "After listening to my declaration, my Grandpa's face changed countless times.",
            "From surprised, disbelief, sad, then...joy and pride.",
            "In the end, he sighed, grabbed both of my shoulders and began staring at me with sharp eyes."
        };

        yield return Narrator.Say(lines6);

        yield return Grandpa.Say("...Child, are you sure that you want to make that your goal?");

        yield return Arkan.Say("I'm sure!");

        yield return Grandpa.Say("Good! From now on, accompany me to visit my old friends. We will teach you how to become Master Angler and replace me to catch that legendary figure!");

        yield return Narrator.Say("Since then, he would seriously teach me the knowledge of fishing.");

        yield return Narrator.Say("Because of that, I've grown up and been known as 'Fishing Genius'.");




        layer0.SetTexture("Graphics/BG Images/scene masuk desa");
        AudioManager1.instance.PlayTrack("Audio/Music/Backsound Market Activity/laurel village", loop: true, volumeCap: 0.7f);

        List<string> lines7 = new List<string>()
        {
            "time goes sure so fast. ItÅfs been 5 years since that promise was made and here we are. To Suangmulak Village. A place that becomes GrandpaÅfs lifelong regret.",
            "Suangmulak village. This is a small village located in the mountains in North Sumatra. {c}Most of the young people go abroad to earn a living, so the average population is older people who have lived there for a long time.",
            "This village has a large lake full of rare fish. {c}According to my Grandpa, because the residents believe in the legend of the Guardian of the Lake, not many villagers try to catch fish there, so the natural resources are still pristine.",
            "There are Anglers who are interested in fishing in this village, but because the legendary fish never appears and most anglers have caught all kinds of rare fish here, this village is not very popular among the angler community.",
            "Even so, I still want to visit this place. For the sake of the promise I made with my grandfather 5 years ago, and for the sake of adventure as an angler.",
            "Of course, a 13 year old child couldn't travel far away alone, so my parent decided to accompany me to this village.",
            "Coincidentally, my grandfather once bought a house in this village. When they found out about this from grandfather before he died, father and mother decided to move to this place together with me."
        };

        yield return Narrator.Say(lines7);


        layer0.SetTexture("Graphics/BG Images/Scene Village");

        yield return new WaitForSeconds(1);

        layer0.SetTexture("Graphics/BG Images/Arkan House");

        yield return Narrator.Say("Not long after, we arrived at our new house.");

        Arkan.SetPosition(Vector2.zero);
        Arkan.TransitionSprite(Arkan.GetSprite("01"));
        Arkan.TransitionSprite(Arkan.GetSprite("01 smile1"), layer: 1);
        Arkan.Show();
        Arkan.FaceRight();

        Dad.SetPosition(new Vector2(0.5f, 0));
        Dad.TransitionSprite(Dad.GetSprite("body"));
        Dad.TransitionSprite(Dad.GetSprite("smile"), layer: 1);
        Dad.Show();

        Mom.SetPosition(new Vector2(1, 0));
        Mom.TransitionSprite(Mom.GetSprite("body"));
        Mom.TransitionSprite(Mom.GetSprite("smile"), layer: 1);
        Mom.Show();

        Arkan.Highlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        yield return Arkan.Say("Wow, traditional house!");
        Arkan.UnHighlight();
        Dad.Highlight();
        Mom.UnHighlight();
        yield return Dad.Say("Haha. Grandpa bought this house from his friend who is a long-time resident here. Because of this, the house design is quite traditional.");

        Arkan.Highlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        yield return Arkan.Say("Ohhh. I See.");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.Highlight();
        yield return Mom.Say("Arkan, please help your father to move things inside.");
        Arkan.Highlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        yield return Arkan.Say("Okay Mom.");


        layer0.SetTexture("Graphics/BG Images/scene ruang tamu rumah arkan");

        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        yield return Narrator.Say("30 minutes later, we finished moving the items to the house.");

        Arkan.Highlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        List<string> lines8 = new List<string>()
        {
            "Phew. finally finished.",
            "Alright. Moving the items is done, helping the father move the furniture is also done, Arranging the goods with the mother is also done.",
            "Now is the time to adventure!"
        };
        yield return Arkan.Say(lines8);
        Arkan.UnHighlight();
        Dad.Highlight();
        Mom.UnHighlight();
        yield return Dad.Say("Ah wait, Arkan!");
        Arkan.Highlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        yield return Arkan.Say("Huh? Is there anything else that hasn't been done, Dad?");
        Arkan.UnHighlight();
        Dad.Highlight();
        Mom.UnHighlight();
        yield return Dad.Say("No. All tasks are completed. It's just that you still don't know the place in this village well enough, so don't go wandering alone. {c}ThereÅfs someone whoÅfs going to introduce you the the village later.");
        Arkan.Highlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        yield return Arkan.Say("Ah, alright, Dad!");

        layer0.SetTexture("Graphics/BG Images/Arkan House");

        Dad.SetPosition(new Vector2(0.25f, 0));
        Dad.TransitionSprite(Dad.GetSprite("body"));
        Dad.TransitionSprite(Dad.GetSprite("smile"), layer: 1);
        Dad.FaceRight();
        Dad.Show();

        Mom.SetPosition(new Vector2(0.5f, 0));
        Mom.TransitionSprite(Mom.GetSprite("body"));
        Mom.TransitionSprite(Mom.GetSprite("smile"), layer: 1);
        Mom.FaceRight();
        Mom.Show();

        Chief.SetPosition(new Vector2(0.75f, 0));
        Chief.TransitionSprite(Chief.GetSprite("body"));
        Chief.TransitionSprite(Chief.GetSprite("smile"), layer: 1);
        Chief.Show();

        Dayana.SetPosition(new Vector2(1, 0));
        Dayana.TransitionSprite(Dayana.GetSprite("01"));
        Dayana.TransitionSprite(Dayana.GetSprite("01 smile1"), layer: 1);
        Dayana.Show();

        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        List<string> lines9 = new List<string>()
        {
            "5 minutes later, I saw a man wearing glasses and a girl wearing a straw hat coming towards us.",
            "The man looked the same age as my father. He dressed simply in green clothes, black pants, and red sash that wrapped around his waist.",
            "the girl looked the same age as me. just like the man, she wore simple clothing, with a black shirt and blue skirt, and a traditional sash tied around her waist."
        };
        yield return Narrator.Say(lines9);
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.Highlight();
        Dayana.UnHighlight();
        yield return Chief.Say("Sorry, I was taking care of some documents in the office and didn't see the time. I didn't make you wait long, right?");
        Arkan.UnHighlight();
        Dad.Highlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        yield return Dad.Say("No, no, it's alright. We also just finished sorting the items at home.");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.Highlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        yield return Mom.Say("Sorry for disturbing your time, the village head.");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.Highlight();
        Dayana.UnHighlight();
        yield return Chief.Say("No, it's okay. This is my job to help newcomers of the village around.");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        yield return Narrator.Say("The village head then looked at me, showing a surprised face, then smiled softly at me.");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.Highlight();
        Dayana.UnHighlight();
        yield return Chief.Say("Ah, are you Arkan?");
        Arkan.Highlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        yield return Arkan.Say("Yes. Hello, Sir! Nice to meet you!");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.Highlight();
        Dayana.UnHighlight();
        yield return Chief.Say("Haha, nice to meet you too, Arkan. IÅfm the village chief of this village. People usually called me Chief. {c}If you have some questions about this village, you can come to me.");
        yield return Chief.Say("I have heard from your parents about your goal here. Even though I don't know if you can see the guardian of the lake later, I hope you can enjoy your time in this village.");
        Arkan.Highlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        yield return Arkan.Say("Yeah! Thank you, Chief!");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        yield return Narrator.Say("I then shifted my gaze towards the girl beside him. Chief noticed it and immediately introduced her to us.");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.Highlight();
        Dayana.UnHighlight();
        yield return Chief.Say("Oh yes, Let me introduce you. She is Dayana, my beloved daughter. Dayana was born and raised here so I think she is suitable to be your guide around the village.");
        Arkan.Highlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        yield return Arkan.Say("Nice to meet you, Dayana!");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.Highlight();
        yield return Dayana.Say("...Nice to meet you.");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        yield return Narrator.Say("Ups, seems like sheÅfs a bit cold.");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.Highlight();
        Dayana.UnHighlight();
        yield return Chief.Say("AhahahaÅc DonÅft worry. SheÅfs just a bit shy.");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        yield return Narrator.Say("Dayana glanced at her father slightly but didn't say anything. She just nodded slightly at me.");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.Highlight();
        Dayana.UnHighlight();
        yield return Chief.Say("Well then, Dayana. You can start introducing this place to Arkan. Arkan's parents and I want to discuss something. Be careful on the way.");
        Arkan.Highlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        yield return Arkan.Say("Okay, Chief!");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.Highlight();
        yield return Dayana.Say("...Okay, Father.");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.Highlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        yield return Mom.Say("Arkan, be nice to Dayana!");
        Arkan.Highlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.UnHighlight();
        yield return Arkan.Say("Okay, Mom!");
        Arkan.UnHighlight();
        Dad.UnHighlight();
        Mom.UnHighlight();
        Chief.UnHighlight();
        Dayana.Highlight();
        yield return Dayana.Say("LetÅfs go.");

        Arkan.Hide();
        Dad.Hide();
        Mom.Hide();
        Chief.Hide();
        Dayana.Hide();




        layer0.SetTexture("Graphics/BG Images/market");
        AudioManager1.instance.PlayTrack("Audio/Music/Backsound Awal/peritune village", channel: 0, loop: true, volumeCap: 0.5f);
        AudioManager1.instance.PlayTrack("Audio/Ambience/marketsibuk", channel: 1, loop: true, volumeCap: 2);

        Dayana.SetPosition(new Vector2(0.8f, 0.2f));
        Dayana.TransitionSprite(Dayana.GetSprite("01"));
        Dayana.TransitionSprite(Dayana.GetSprite("01 hah"), layer: 1);
        Dayana.Show();

        Arkan.SetPosition(new Vector2(0.2f, -0.2f));
        Arkan.TransitionSprite(Arkan.GetSprite("01"));
        Arkan.TransitionSprite(Arkan.GetSprite("01 smile1"), layer: 1);
        Arkan.Show();
        Arkan.FaceRight();

        Arkan.UnHighlight();
        yield return Dayana.Say("The first place is the market.{c}This place is located in the middle between the residential area and the village dock. {c}Here{wa 0.5} you can buy various items you need for fishing or sell the fish you catch on the lake.");

        Dayana.UnHighlight();
        Arkan.MoveToPosition(new Vector2(-0.5f, 0), smooth: true);
        Dayana.MoveToPosition(new Vector2(-0.5f, 0.2f), smooth: true);
        layer0.SetTexture("Graphics/BG Images/Fishing Tackle Shop joko", blendingTexture: leftRight);

        Arkan.Hide();
        Dayana.Hide();
        Arkan.SetPosition(new Vector2(2, 0));
        Dayana.SetPosition(new Vector2(2, 0));


        yield return new WaitForSeconds(0.8f);

        Arkan.Show();
        Dayana.Show();
        Arkan.FaceLeft();
        Arkan.MoveToPosition(new Vector2(0.2f, -0.2f), smooth: true);
        Dayana.MoveToPosition(new Vector2(0.8f, 0.2f), smooth: true);

        yield return new WaitForSeconds(0.8f);
        Arkan.FaceRight();

        Dayana.Highlight();
        yield return Dayana.Say("To buy fishing equipment, you can visit Pak Joko's shop. He is the only fishing gear seller here. you can visit here if you want to improve your fishing gear.");

        Dayana.UnHighlight();
        yield return HidJoko.Say("Hm? Oh hey! Isn't this Dayana? Hey, I rarely see you at the market, once I see you, you actually bring new friends here.");

        Dayana.Highlight();
        Arkan.Highlight();
        HidJoko.Highlight();
        HidJoko.SetPosition(new Vector2(2, 0));
        HidJoko.Show();
        HidJoko.MoveToPosition(new Vector2(1, 0), smooth: true);

        yield return new WaitForSeconds(0.8f);
        Dayana.MoveToPosition(new Vector2(0.6f, 0), smooth: true);

        yield return new WaitForSeconds(1);

        yield return Narrator.Say("Suddenly an uncle appeared, around 35 years old. he wore clothes with predominantly brown, red, and orange colors and wore brown high boots. He came with a big smile when he saw Dayana.");

        Arkan.UnHighlight();
        HidJoko.UnHighlight();
        Dayana.FaceRight();
        yield return Dayana.Say("....uncle Joko.");

        Joko.SetPosition(new Vector2(1, 0));
        HidJoko.Hide();
        Joko.Show();
        Joko.Highlight();
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        yield return Joko.Say("Ahahaha. you are still taciturn as always huh, Dayana.");

        Joko.UnHighlight();
        Arkan.UnHighlight();
        Dayana.Highlight();
        Dayana.TransitionSprite(Dayana.GetSprite("01 sad"), layer: 1);
        yield return Dayana.Say("...IÅfm sorry.");

        Joko.Highlight();
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Joko.TransitionSprite(Joko.GetSprite("oh"), layer: 1);
        Joko.Animate("Hop");
        yield return Joko.Say("Uh, No, that's not what I meant. Ugh.");

        Dayana.TransitionSprite(Dayana.GetSprite("01 hah"), layer: 1);

        Joko.FaceRight(speed: 0.8f);

        yield return new WaitForSeconds(1);


        Joko.FaceLeft(speed: 0.8f);

        yield return new WaitForSeconds(1);

        yield return Narrator.Say("Pak Joko looked flustered by Dayana's reaction. he turned his head here and there to change the conversation and focused his gaze on me.");

        Joko.TransitionSprite(Joko.GetSprite("he"), layer: 1);
        Joko.Animate("Hop");
        yield return Joko.Say("Oh right!");

        yield return Joko.Say("kid. I've never seen you before. Are you the newcomer that the chief said was moving to this village?");

        Joko.UnHighlight();
        Arkan.Highlight();
        Dayana.UnHighlight();
        Arkan.TransitionSprite(Arkan.GetSprite("01 smile2"), layer: 1);
        Arkan.Animate("Hop");
        yield return Arkan.Say("Yup. hello uncle, nice to meet you. my name is Arkan and my goal is to become a master angler!");

        Joko.Highlight();
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Arkan.TransitionSprite(Arkan.GetSprite("01 smile1"), layer: 1);
        Joko.Animate("Hop");
        yield return Joko.Say("OH!! that's a great goal!");

        Joko.TransitionSprite(Joko.GetSprite("smile"), layer: 1);
        yield return Joko.Say("My name is Joko, I am the owner of this shop. Dayana has probably already introduced you to this place, so I won't repeat myself twice. You just need to know that good fishing gear will make it easier for you to catch fish, so don't hesitate to improve your fishing gear.");

        Joko.UnHighlight();
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        yield return Buyer.Say("Hey, uncle, I want to buy this fishing rod!");
        Joko.Highlight();
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Joko.FaceRight();
        Joko.TransitionSprite(Joko.GetSprite("he"), layer: 1);
        yield return Joko.Say("I'm coming!");
        Joko.FaceLeft();
        yield return Joko.Say("Well, my customers are waiting. Have fun, you guys. And Arkan, I hope you enjoy this village. Make sure to catch all the fish on the lake to your heart's content! Hahahaha!");

        Joko.UnHighlight();
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Joko.FaceRight();
        yield return new WaitForSeconds(0.5f);
        Joko.MoveToPosition(new Vector2(2, 0), smooth: true);
        Dayana.FaceRight();
        Dayana.MoveToPosition(new Vector2(0.8f, 0.2f), smooth: true);
        yield return Narrator.Say("Pak Joko then went to serve his customers.");

        Arkan.Highlight();
        Dayana.UnHighlight();
        Joko.Animate("Hop");
        yield return Arkan.Say("Huh, he's quite a cheerful uncle, isn't he, Dayana?");

        Arkan.UnHighlight();
        Dayana.Highlight();
        Dayana.FaceLeft();
        yield return Dayana.Say("Yeah. he is also skilled at making good fishing equipment so I suggest you upgrade your fishing equipment here.");

        Arkan.Highlight();
        Dayana.UnHighlight();
        Arkan.TransitionSprite(Arkan.GetSprite("01 surprised"), layer: 1);
        yield return Arkan.Say("Huh?");

        Arkan.UnHighlight();
        Dayana.Highlight();
        Dayana.FaceRight();
        yield return Dayana.Say("Let's go.");

        Arkan.Highlight();
        Dayana.UnHighlight();
        Dayana.MoveToPosition(new Vector2(2, 0.2f), smooth: true);
        Arkan.TransitionSprite(Arkan.GetSprite("01 smile2"), layer: 1);
        yield return Narrator.Say("Just now... was she trying to help Mr Joko advertise his shop?");
        yield return Narrator.Say("Pfft. Hahahaha. Well, arenÅft that cute?");

        Arkan.Hide();





        layer0.SetTexture("Graphics/BG Images/toko moms gosip");
        AudioManager1.instance.PlayTrack("Audio/Music/Backsound Awal/peritune village", channel: 0, loop: true, volumeCap: 0.5f);
        AudioManager1.instance.PlayTrack("Audio/Ambience/marketsibuk", channel: 1, loop: true, volumeCap: 2);

        Dayana.MoveToPosition(new Vector2(0.5f, 0.2f), smooth: true);
        Dayana.TransitionSprite(Dayana.GetSprite("01"));
        Dayana.TransitionSprite(Dayana.GetSprite("01 hah"), layer: 1);
        Dayana.Show();

        Arkan.SetPosition(new Vector2(0, -0.2f));
        Arkan.TransitionSprite(Arkan.GetSprite("01"));
        Arkan.TransitionSprite(Arkan.GetSprite("01 smile1"), layer: 1);
        Arkan.Show();
        Arkan.FaceRight();

        HidAunt.TransitionSprite(HidAunt.GetSprite("01"));
        HidAunt.TransitionSprite(HidAunt.GetSprite("smile"), layer: 1);
        Aunt.TransitionSprite(Aunt.GetSprite("01"));
        Aunt.TransitionSprite(Aunt.GetSprite("smile"), layer: 1);

        Arkan.UnHighlight();
        Dayana.Highlight();
        yield return Dayana.Say("The next place is a grocery store. the owner is an aunt who has lived in this village for a long time. {c}She usually wants to buy fish caught by anglers who come to visit this village, so if you want to sell the fish you catch, you can sell it here.");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        yield return HidAunt.Say("Oh. Dayana! HavenÅft seen you for a long time!");

        HidAunt.SetPosition(new Vector2(2, 0));
        HidAunt.Show();
        HidAunt.MoveToPosition(new Vector2(1, 0), smooth: true);

        yield return new WaitForSeconds(0.8f);
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        HidAunt.UnHighlight();
        yield return Narrator.Say("This time an aunt appeared with a friendly smile. Just like Mr. Joko earlier, she seemed surprised to see Dayana's presence in this market, but she seemed happy because of it.");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        HidAunt.Highlight();
        yield return HidAunt.Say("Hey, Dayana. you haven't been here for a long time. Auntie misses you.");

        Aunt.SetPosition(new Vector2(1, 0));
        HidAunt.Hide();
        Aunt.Show();

        Arkan.UnHighlight();
        Dayana.Highlight();
        Aunt.UnHighlight();
        yield return Dayana.Say("Uh... hello, Auntie.");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.UnHighlight();
        yield return Narrator.Say("Right after Dayana replied to her, she immediately hugged Dayana in a tight hug. Dayana did not appear to show any resistance. She looked like she was resign herself up to be trapped in her aunt's arms.");
        yield return Narrator.Say("Haha, it seems like Dayana is used to being treated like that by that Auntie.");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.Highlight();
        yield return Aunt.Say("Hm? oh? Who's this? the new kid? I've never seen your face before.");
        yield return Aunt.Say("Ah! Oh yes. I just remembered that the chief reported that we have new arrivals in this village. So, are you the newcomer?");
        Arkan.Highlight();
        Dayana.UnHighlight();
        Aunt.UnHighlight();
        yield return Arkan.Say("Haha, hello auntie. pleased to meet you. My name is Arkan and I just moved to this village with my parents.");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.Highlight();
        yield return Aunt.Say("Oh!! I thought it was you. Hehe, I remember all the residents in this village but I never saw you before, so I thought you were the newcomer.");
        yield return Aunt.Say("Is Dayana taking you around the village? how lucky. Dayana, this child, always retreats to the edge of the lake. I rarely see her visit this place.");
        Arkan.Highlight();
        Dayana.UnHighlight();
        Aunt.UnHighlight();
        yield return Arkan.Say("Huh? Is that true?");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.Highlight();
        yield return Aunt.Say("Yup! Since 5 years ago, Dayana has started to be alone and stay away from residential areas. Her nature is also becoming more and more introverted. I'm curious why she's like that.");
        Arkan.UnHighlight();
        Dayana.Highlight();
        Aunt.UnHighlight();
        yield return Dayana.Say("Auntie... you don't need to tell him about that.");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.Highlight();
        yield return Aunt.Say("Ah! Sorry. Sorry. ugh, my habit of gossiping makes me unable to control my mouth. Sorry, Dayana.");
        Arkan.UnHighlight();
        Dayana.Highlight();
        Aunt.UnHighlight();
        yield return Dayana.Say("It's okay, auntie.");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.Highlight();
        yield return Aunt.Say("So, Arkan, where have you been around?");
        Arkan.Highlight();
        Dayana.UnHighlight();
        Aunt.UnHighlight();
        yield return Arkan.Say("Dayana has just introduced this market. We also went to Mr Joko's fishing gear shop just before. Dayana was introducing me to this shop before Auntie appeared.");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.Highlight();
        yield return Aunt.Say("Oh really? Haha, that's great. This shop is mine. I usually sell various goods here. Remembering that the village head said that you were an angler, I thought it would be good if you sold the fish you caught here. {c}The residents of this village rarely catch their own fish, and we also don't consume much fish. However, tourists who come to this place tend to buy fish here as souvenirs. {c}I also have a business partnership to import these fish out there so I need a lot of fish to sell.");
        yield return Aunt.Say("Of course, I will buy the fish you sell at the right price. after all, you are a new resident of this village, so I won't cheat you when I buy fish from you.");
        Arkan.Highlight();
        Dayana.UnHighlight();
        Aunt.UnHighlight();
        yield return Arkan.Say("Huh?");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.UnHighlight();
        yield return Narrator.Say("Doesn't that mean... this aunt is cheating on prices for the tourists who came here?");
        yield return Narrator.Say("Seeing my confused face, Auntie just smiled mischievously.");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.Highlight();
        yield return Aunt.Say("Haha. If you live in a place that is often visited by tourists, of course, you have to do certain tricks. This has become a public secret for sellers.");
        Arkan.Highlight();
        Dayana.UnHighlight();
        Aunt.UnHighlight();
        yield return Arkan.Say("!!!");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.UnHighlight();
        yield return Narrator.Say("Geez. I didn't expect an aunt with a friendly smile like you to have that kind of character. this opened my eyes.");
        Arkan.UnHighlight();
        Dayana.Highlight();
        Aunt.UnHighlight();
        yield return Dayana.Say("Don't believe her words. She's just teasing you.");
        Arkan.Highlight();
        Dayana.UnHighlight();
        Aunt.UnHighlight();
        yield return Arkan.Say("Huh???");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.Highlight();
        yield return Aunt.Say("Oh my goodness, Dayana. how could you just dismantle it like that? Now Arkan knows.");
        Arkan.Highlight();
        Dayana.UnHighlight();
        Aunt.UnHighlight();
        yield return Arkan.Say("Wait.");
        yield return Arkan.Say("Was that a lie???");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.Highlight();
        yield return Aunt.Say("Hahahahaha");
        yield return Aunt.Say("You're so funny Arkan.");
        yield return Aunt.Say("Well, I still have to continue selling so I'll go first. Come see me often, okay?");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        Aunt.UnHighlight();

        Aunt.FaceRight();
        yield return new WaitForSeconds(0.5f);
        Aunt.MoveToPosition(new Vector2(2, 0), smooth: true);

        Arkan.Highlight();
        Dayana.UnHighlight();
        yield return Arkan.Say("???");
        Arkan.UnHighlight();
        Dayana.UnHighlight();
        yield return Narrator.Say("Huh");
        yield return Narrator.Say("Wait.");
        Arkan.Highlight();
        Dayana.UnHighlight();
        yield return Arkan.Say("So was that a lie or not?");
        Arkan.UnHighlight();
        Dayana.Highlight();
        yield return Dayana.Say("...");
        yield return Dayana.Say("let's continue.");
        Arkan.Highlight();
        Dayana.UnHighlight();
        yield return Arkan.Say("Eh wait, dayana! Hey!");

        Arkan.Hide();
        Dayana.Hide();




        AudioManager1.instance.StopTrack(channel: 1);

        layer0.SetTexture("Graphics/BG Images/BG Gubuk dok");
        AudioManager1.instance.PlayTrack("Audio/Music/Backsound Market Activity/laurel village", loop: true, volumeCap: 0.7f);

        Dayana.SetPosition(new Vector2(0.5f, 0.2f));
        Dayana.TransitionSprite(Dayana.GetSprite("01"));
        Dayana.TransitionSprite(Dayana.GetSprite("01 hah"), layer: 1);
        Dayana.Show();

        Arkan.SetPosition(new Vector2(0, -0.2f));
        Arkan.TransitionSprite(Arkan.GetSprite("01"));
        Arkan.TransitionSprite(Arkan.GetSprite("01 smile1"), layer: 1);
        Arkan.Show();
        Arkan.FaceRight();

        Maman.TransitionSprite(Maman.GetSprite("body"));
        Maman.TransitionSprite(Maman.GetSprite("smile"), layer: 1);
        Maman.SetPosition(new Vector2(1, 0));

        Dayana.Highlight();
        Arkan.UnHighlight();
        List<string> lines10 = new List<string>()
        {
            "The last place is the dock. This is the most popular place visited by anglers.",
            "Do you see that hut?",
            "It was Mr. Maman's hut. He is a boat keeper near this dock and he provides boat upgrade services. {c}Even though there are boats that have been specially provided for anglers here, if you feel that your boat needs a performance upgrade, you can go to Mr Maman to have it upgraded.",
            "LetÅfs go. let me introduce you to him"
        };
        yield return Dayana.Say(lines10);

        layer0.SetTexture("Graphics/BG Images/BG Gubuk dok 2");

        Maman.Show();

        Dayana.Highlight();
        Arkan.UnHighlight();
        Maman.UnHighlight();
        yield return Dayana.Say("Hello, uncle maman.");
        Dayana.UnHighlight();
        Arkan.UnHighlight();
        Maman.Highlight();
        yield return Maman.Say("Huh? Dayana. is there anything I can help you with?");
        Dayana.Highlight();
        Arkan.UnHighlight();
        Maman.UnHighlight();
        yield return Dayana.Say("I'm introducing Arkan around the village. Since he's an angler, I think it's necessary to introduce the two of you.");
        Dayana.UnHighlight();
        Arkan.UnHighlight();
        Maman.Highlight();
        yield return Maman.Say("Oh? angler? this young? You are quite talented, kid.");
        Dayana.UnHighlight();
        Arkan.Highlight();
        Maman.UnHighlight();
        yield return Arkan.Say("Hehe, nice to meet you, sir maman.");
        Dayana.UnHighlight();
        Arkan.UnHighlight();
        Maman.Highlight();
        yield return Maman.Say("Well, nice to meet you too, kid.");
        yield return Maman.Say("My name is maman. I'm the keeper of the boat that's anchored at this dock. {c}There are special boats provided free of charge to anglers here. you can use it anytime. {c}but if you need a higher-performance boat, you can upgrade it to me. of course, after you pay the appropriate fee.");
        Dayana.Highlight();
        Arkan.UnHighlight();
        Maman.UnHighlight();
        yield return Dayana.Say("Arkan is a new resident of this village, Uncle. He just moved in today.");
        Dayana.UnHighlight();
        Arkan.UnHighlight();
        Maman.Highlight();
        yield return Maman.Say("Huh? Ah... so you're the newcomer the chief said at the time. I just remembered he said that the couple had a son who was an angler. sorry, I almost forgot about that.");
        yield return Maman.Say("Well, because you are now a resident of this village. I will give you a small discount every time you want to upgrade your boat. considering this as a newcomer bonus.");
        Dayana.UnHighlight();
        Arkan.Highlight();
        Maman.UnHighlight();
        yield return Arkan.Say("Wow! thank you, Uncle!");
        Dayana.UnHighlight();
        Arkan.UnHighlight();
        Maman.Highlight();
        yield return Maman.Say("Haha. You're welcome, kid.");

        Maman.Hide();

        layer0.SetTexture("Graphics/BG Images/BG Gubuk dok");
        Dayana.Highlight();
        Arkan.UnHighlight();
        yield return Dayana.Say("Well, you've toured this village, and my task is finished. Do you still remember the way to the places we visited?");
        Dayana.UnHighlight();
        Arkan.Highlight();
        yield return Arkan.Say("Of course! My memory is very good, I have memorized this place.");
        Dayana.Highlight();
        Arkan.UnHighlight();
        yield return Dayana.Say("That's good.");
        yield return Dayana.Say("Then... goodbye.");
        Dayana.UnHighlight();
        Arkan.Highlight();
        yield return Arkan.Say("Huh? are you leaving?");
        Dayana.Highlight();
        Arkan.UnHighlight();
        yield return Dayana.Say("Yeah, my job is done, and you've memorized this place. Next, you can do whatever you want.");
        Dayana.UnHighlight();
        Arkan.Highlight();
        yield return Arkan.Say("Ugh...");
        Dayana.Highlight();
        Arkan.UnHighlight();
        yield return Dayana.Say("Is there anything you want to say?");
        Dayana.UnHighlight();
        Arkan.Highlight();
        yield return Arkan.Say("No! There isn't any. Um, thank you, Dayana. has taken me around the village. I know this is your job but you explained it well to me.");
        Dayana.Highlight();
        Arkan.UnHighlight();
        yield return Dayana.Say("Yeah. You're welcome.");
        yield return Dayana.Say("Well, if there's nothing you want to talk about anymore. I go.");
        Dayana.UnHighlight();
        Arkan.Highlight();
        yield return Arkan.Say("Uhh, thanks for showing me around. Bye Dayana. let's meet again later.");
        Dayana.Highlight();
        Arkan.UnHighlight();
        yield return Dayana.Say("yeah, bye.");
        Dayana.Hide();
        Dayana.UnHighlight();
        Arkan.UnHighlight();
        yield return Narrator.Say("Huh.");
        yield return Narrator.Say("SheÅfs surprisingly is pretty good.");
        Dayana.UnHighlight();
        Arkan.Highlight();
        yield return Arkan.Say("Now then, what should I do next?");

        AudioManager1.instance.StopTrack(channel: 0);
        AudioManager1.instance.StopTrack(channel: 1);
        SceneManager.LoadScene("Dock");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            DialogueSystem.instance.dialogueContainer.Hide();

        else if (Input.GetKeyDown(KeyCode.UpArrow))
            DialogueSystem.instance.dialogueContainer.Show();
    }
}
