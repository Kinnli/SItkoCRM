import React, {Component} from 'react';

// Material helpers
import {withStyles} from '@material-ui/core';

// Material components
import {CircularProgress, Typography} from '@material-ui/core';

// Shared layouts
import {Dashboard as DashboardLayout} from 'layouts';

// Shared services
import {getUsers} from 'services/user';

// Custom components
import {UsersToolbar, UsersTable} from './components';

// Component styles
import styles from './style';
import {ClientsService} from '../../components/services/ClientsService';
import {Client} from '../../components/entities/Client';

interface UserListState {
    classes: any;
}

class UserList extends Component<UserListState> {
    signal = true;

    state = {
        isLoading: false,
        limit: 10,
        users: [],
        selectedUsers: [],
        error: null
    };

    async getUsers() {
        try {
            this.setState({isLoading: true});

            const {limit} = this.state;

            let clientsService = new ClientsService();
            const result = await clientsService.getAll();
            if (result.statusCode == 200 && result.result !== null) {
                const users = result.result.data;

                if (this.signal) {
                    this.setState({
                        isLoading: false,
                        users
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

    componentDidMount() {
        this.signal = true;
        this.getUsers();
    }

    componentWillUnmount() {
        this.signal = false;
    }

    handleSelect = selectedUsers => {
        this.setState({selectedUsers});
    };

    renderUsers() {
        const {classes} = this.props;
        const {isLoading, users, error} = this.state;

        if (isLoading) {
            return (
                <div className={classes.progressWrapper}>
                    <CircularProgress/>
                </div>
            );
        }

        if (error) {
            return <Typography variant="h6">{error}</Typography>;
        }

        if (users.length === 0) {
            return <Typography variant="h6">There are no users</Typography>;
        }

        return (
            <UsersTable
                //
                onSelect={this.handleSelect}
                users={users}
            />
        );
    }

    render() {
        const {classes} = this.props;
        const {selectedUsers} = this.state;

        return (
            <DashboardLayout title="Users">
                <div className={classes.root}>
                    <UsersToolbar selectedUsers={selectedUsers}/>
                    <div className={classes.content}>{this.renderUsers()}</div>
                </div>
            </DashboardLayout>
        );
    }
}

export default withStyles(styles)(UserList);
