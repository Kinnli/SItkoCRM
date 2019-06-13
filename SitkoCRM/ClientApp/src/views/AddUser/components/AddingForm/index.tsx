import React, { Component } from 'react';

// Shared services
import { getUsers } from 'services/user';

import classNames from 'classnames';

// Material helpers
import { withStyles } from '@material-ui/core';

// Material components
import { Avatar, Typography, Button, LinearProgress } from '@material-ui/core';

import {
    Portlet,
    PortletHeader,
    PortletLabel,
    PortletContent,
    PortletFooter
} from 'components';

import {TextField } from '@material-ui/core';

// Component styles
import styles from './style';

import { ClientsService } from 'components/services/ClientsService';
import { Client } from 'components/entities/Client';

interface UserState {
    classes: any;
    className:string;
}

class AddUser extends Component<UserState> {

    signal = true;

    state = {
        isLoading: false,
        user : '',
        error: null
    };

    async addUser() {
        try {
            this.setState({ isLoading: true });

            let clientsService = new ClientsService();
            let client = new Client();
            client.name = this.state.user;
            const result = await clientsService.add(client);
            if (result.statusCode == 201 && result.result !== null) {
                const user = client.name;

                if (this.signal) {
                    this.setState({
                        isLoading: false,
                        user
                    });
                }
            }


        } catch (error) {
            if (this.signal) {
                this.setState({
                    isLoading: false,
                    error
                });
            }
        }
    }

    handleSubmit = e => {
        this.addUser();
        e.preventDefault();
    }

    handleChange = e => {
        this.setState({
            user: e.target.value
        });
    };

/*
 *  <form onSubmit={this.handleSubmit}>
                <label>
                    Имя:
                    <input type="text" value={this.state.user} onChange={this.handleChange} />
                </label>
                <input type="submit" value="Отправить" />
            </form>

 <div className={classes.field}>
                            <TextField
                                className={classes.textField}
                                label="Select State"
                                margin="dense"
                                onChange={this.handleChange}
                                required
                                select
                                SelectProps={{ native: true }}
                                value={this.state.user}
                                variant="outlined">
                                {states.map(option => (
                                    <option
                                        key={option.value}
                                        value={option.value}
                                    >
                                        {option.label}
                                    </option>
                                ))}
                            </TextField>
                            <TextField
                                className={classes.textField}
                                label="Country"
                                margin="dense"
                                required
                                value={country}
                                variant="outlined"
                            />
                        </div>
 */

    render() {

        const { classes, className, ...rest } = this.props;
        const rootClassName = classNames(classes.root, className);

        return (
            <Portlet
                {...rest}
                className={rootClassName}
            >
                <PortletHeader>
                    <PortletLabel
                        subtitle="The information can be edited"
                        title="Profile"
                    />
                </PortletHeader>
                <PortletContent noPadding>
                    <form
                        autoComplete="off"
                        noValidate
                    >
                        <div className={classes.field}>
                            <TextField
                                className={classes.textField}
                                helperText="Please specify the first name"
                                label="First name"
                                margin="dense"
                                required
                                value={this.state.user}
                                onChange={this.handleChange}
                                variant="outlined"
                            />
                        </div>
                    </form>
                </PortletContent>
                <PortletFooter className={classes.portletFooter}>
                    <Button
                        color="primary"
                        variant="contained"
                        onClick={this.handleSubmit}
                    >
                        Save details
          </Button>
                </PortletFooter>
            </Portlet>
        );
    }
}

export default withStyles(styles)(AddUser);

