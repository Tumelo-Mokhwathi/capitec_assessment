import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateModal } from '../components/modal/create/modal.component';
import { RemoveModal } from '../components/modal/remove/modal.component';
import { UpdateModal } from '../components/modal/update/modal.component';
import { MarkAsPaidModal } from '../components/modal/markAsPaid/markAsPaid.component';

type ModalComponentsMap = { [key: string]: any; };

@Injectable({
    providedIn: 'root',
})
export class ModalService {
    modalComponents: ModalComponentsMap = {
        create: CreateModal,
        remove: RemoveModal,
        update: UpdateModal,
        markAsPaid: MarkAsPaidModal
    };
    constructor(private dialog: MatDialog) { }

    createModal(modalType: string) {
        const dialogRef = this.dialog.open(this.modalComponents[modalType], {
            width: '400px',
            height: '550px'
        });

        return dialogRef.afterClosed();
    }

    removeModal(data: any, modalType: string) {
        const dialogRef = this.dialog.open(this.modalComponents[modalType], {
            width: '500px',
            height: '400px',
            data: data
        });

        return dialogRef.afterClosed();
    }

    updateModal(data: any, modalType: string) {
        const dialogRef = this.dialog.open(this.modalComponents[modalType], {
            width: '400px',
            height: '500px',
            data: data
        });

        return dialogRef.afterClosed();
    }

    markAsPaid(data: any, modalType: string) {
        const dialogRef = this.dialog.open(this.modalComponents[modalType], {
            width: '500px',
            height: '180px',
            data: data
        });

        return dialogRef.afterClosed();
    }
}
