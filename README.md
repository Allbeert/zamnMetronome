zamnMetronome
=============
---

Basic metronome for timing accurately after a trigger

### Usage 

```zamnMetronome.exe [InitialDelay] [SpeakerDelay] [BeepLength]```

All values in ms

InitialDelay:

For 100% -> 160ms

For any% -> 40ms
              
Default BeepLength of 100ms if not entered.

The metronome will start as soon as any key is pressed. To stop the metronome, simply press `ESC`, and it will get ready for another run by itself. To actually exit, press `ESC` a few times more, or `CTLR+C` will always work.

### How to calibrate

The only thing that needs to be calibrated is the `SpeakerDelay`
1. Run the metronome with arguments `0 0`
2. Start the metronome and LiveSplit (or similar) at the same time.
   - The easiest way to go about this is setting LiveSplit hotkeys to global, and having focus on the metronome window.
3. Attempt to stop the timer at a round second. But do so only by listening to the metronome.
4. Repeat step 3 a few times. You should note that the offset should be fairly consistent, varying only by a couple ms at most.
5. That is your new `SpeakerDelay`
   - In my case I usually see a 0.1s offset, so my `SpeakerDelay` is of 100ms
6. You can test this by running the metronome with arguments `0 [SpeakerDelay]`, with `SpeakerDelay` being the number you just found.
   - In this case, you should be able to stop the timer at a round second +- 0.01s, which is good enough for what we're trying to do.
