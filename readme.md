ความเป็นมาของโปรแกรม **โปรเตคนี้ได้รับความคิดมากจากการทำการประเมินคะนนงานกลุ่ม ทำให้ผมรู้สึกว่าการพิมมันช้าและไม่สะดวก**<br>
วัตถุประสงค์ของโปรแกรม **เพื่อความสะดวกสบายในการประเมินคะแนนงานกลุ่ม**<br>
โครงสร้างของโปรแกรม (Class diagram)

```mermaid
classDiagram
    class Person{
    Person: -String id
    Person: -String firstname
    Person: -String lastname
    Person: -int leadership
    Person: -int ontime
    Person: -int dutiful
    Person: -int giveusefulinfomation
    +id(return id) string
    +Firstname(return firstname) string
    +Lastname(return lastname) string
    +leadership(return leadership) int
    +ontiome(return ontime) int
    +dutiful(return dutiful) int
    +giveusefulinfomation(return giveusefulinfomation) int
    }
    
    class gridps{
    +id(get; set;)string
    +firstname(get; set;)string
    +lastname(get; set;)string;
    }
    
    
```
<br>
ชื่อของผู้พัฒนาโปรแกรม นันธวัฒน์ แผ่ความดี<br>
Hello Teacher
