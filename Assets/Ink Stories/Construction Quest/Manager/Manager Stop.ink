INCLUDE ../../LicketySplit.ink

->intro

=== intro
~SetSpeaker("Construction Manager")
WHOA- whoa, you're ruining my flow right now. Hear it? Ksst vvvrrrr bv bv BVVV SKRR 
Oh, right, you were trying to get in- HEY YOU CAN'T DO THAT! GET OUTTA HERE!
* [TALK] -> talk_dialog
* [THREATEN] -> threaten_dialog
* [LEAVE] -> leave_dialog

== talk_dialog
~SetSpeaker("Construction Manager")
Y-You!! What did you say to me? I'll have you know my musical career is going GREAT!! You heard it yourself! Krrss- bvvv, ksh ksh kwaaaaahh 
NOW GET OUT OF HERE! ->END

== threaten_dialog
~SetSpeaker("Construction Manager")
...Is that a gun?
~SetSpeaker("Bee")
... ->END

== leave_dialog
~SetSpeaker("Construction Manager")
Yeah, yeah, scram and don't come back. We have a deadline to keep. And I have some ill beats to keep jamming to. VVV, VVV, KSSSSS ->END