import * as React from 'react';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import Avatar from '@mui/material/Avatar';
import { Button, IconButton } from '@mui/material';
import SendIcon from '@mui/icons-material/Send';
import { Close, Done, HourglassEmpty } from '@mui/icons-material';
import {MobileView} from 'react-device-detect';
export default function WaitingList() {
  return (
    <List sx={{ width: '100%', maxWidth: 360, bgcolor: 'background.paper' }}>
      <ListItem>
        <ListItemAvatar>
          <Avatar>
            <HourglassEmpty/>
          </Avatar>
        </ListItemAvatar>
        
        
        <ListItemText primary="Joe Walker" secondary="Jan 9, 2024"></ListItemText>
        <MobileView>
          <Button variant="contained" href='sms:07395522218?body=Hi Joe,%0a%0aHilton driving school here. We added you to our waiting list a while ago and were wondering if you are still interested in driving lessons.%0a%0aCheers Mark' endIcon={<SendIcon />}>
              Send
          </Button>
        </MobileView>
        
        <IconButton aria-label="fingerprint" color="success">
            <Done />
        </IconButton>
        <IconButton aria-label="fingerprint" color="secondary">
            <Close />
        </IconButton>
      </ListItem>
      <ListItem>
        <ListItemAvatar>
          <Avatar>
            <HourglassEmpty/>
          </Avatar>
        </ListItemAvatar>
        
        
        <ListItemText primary="Sam Walker" secondary="Jan 9, 2024"></ListItemText>
        <MobileView>
          <Button variant="contained" href='sms:07564282030?body=Hi Sam,%0a%0aHilton driving school here. We added you to our waiting list a while ago and were wondering if you are still interested in driving lessons.%0a%0aCheers Mark' endIcon={<SendIcon />}>
              Send
          </Button>
        </MobileView>
        
        <IconButton aria-label="fingerprint" color="success">
            <Done />
        </IconButton>
        <IconButton aria-label="fingerprint" color="secondary">
            <Close />
        </IconButton>
      </ListItem>
    </List>
  );
}